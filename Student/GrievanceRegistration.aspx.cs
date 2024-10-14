using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Student_GrievanceRegistration : System.Web.UI.Page
{
    ConnectionClass cc = new ConnectionClass();
    SqlCommand cmd;
    Aesenc aes = new Aesenc();
    DataTable dt;
    string sql = "";
    string res;
    string validatemsg = "";
    Regex r;
    string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        try
        {
            if (!IsPostBack)
            {
                loadgrievancetype();
                Session["token"] = DateTime.Now.Ticks.ToString();
                txtname.Text = Session["name"].ToString();
                txtemail.Text = Session["email"].ToString();
            }

        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong");
        }
    }

    private void loadgrievancetype()
    {
        try
        {
            sql = "select * from grievancetype where status = '1'";
            dt = cc.FillTable(sql);
            if (dt.Rows.Count > 0)
            {
                drpgrievancetype.Items.Clear();
                drpgrievancetype.DataSource = dt;
                drpgrievancetype.DataTextField = "categoryname";
                drpgrievancetype.DataValueField = "categoryid";
                drpgrievancetype.DataBind();
                drpgrievancetype.Items.Insert(0, "Select");
            }
        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong");
        }
    }

    private void loadgrievancesubtype()
    {
        try
        {
            if (drpgrievancetype.SelectedIndex > 0)
            {
                sql = "select * from grievancesubtype where status = '1' and categoryid = '" + drpgrievancetype.SelectedValue + "'";
                dt = cc.FillTable(sql);
                if (dt.Rows.Count > 0)
                {
                    drpgrievancesubtype.Items.Clear();
                    drpgrievancesubtype.DataSource = dt;
                    drpgrievancesubtype.DataTextField = "subcategoryname";
                    drpgrievancesubtype.DataValueField = "subcategoryid";
                    drpgrievancesubtype.DataBind();
                    drpgrievancesubtype.Items.Insert(0, "Select");
                }
            }
        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong");
        }
    }

    private string validateeverything()
    {
        if (drpgrievancetype.SelectedIndex == 0)
        {
            return ("Grievance Type Cannot Be Blank");
        }

        //-------------------------------------------------------------

        if (txtgrievancedetails.Text.Trim() != "")
        {
            r = new Regex(@"^([a-zA-Z0-9,]+\s)*[a-zA-Z0-9,]+$");
            if (!r.IsMatch(txtgrievancedetails.Text))
            {
                return ("Enter Proper Remarks");
            }
        }

        if (fileupload.HasFile)
        {
            if (fileupload.PostedFile.ContentLength > 204800) // document size  200kb
            {
                return "File Size Should Be less than 200KB ";
            }
            string ext = Path.GetExtension(fileupload.PostedFile.FileName);
            if (ext != ".pdf" && ext != ".png" && ext != ".jpeg" && ext != ".jpg")
            {
                return ("File Type Should be of PDF or PNG or JPEG or JPG");
            }
        }
        else
        {
            return ("Upload File of Type PDF or PNG or JPEG or JPG");
        }

        //-----------------------------------------------------------------

        return "";
    }

    protected void drpgrievancetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpgrievancetype.SelectedIndex > 0)
        {
            loadgrievancesubtype();
        }
        else
        {
            drpgrievancesubtype.Items.Clear();
        }
    }

    public string fileID()
    {
        return Guid.NewGuid().ToString("N");
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Session["token"] != null)
        {
            string filename = "";
            string extension = "";
            string dburl = "";
            string name = "";
            string email = "";
            string id = "";
            string savepath = "";
            string serversavepath = "";
            try
            {
                validatemsg = validateeverything();

                if (validatemsg != "")
                {
                    cc.messageweb(this, validatemsg);
                }
                else
                {
                    //if (!Directory.Exists(cc.directorypath + cc.userdocumentpath))
                    //{
                    //    Directory.CreateDirectory(cc.directorypath + cc.userdocumentpath);
                    //}
                    if (fileupload.HasFile)
                    {
                        extension = Path.GetExtension(fileupload.FileName);
                        filename = fileID();
                        dburl = cc.userdocumentpath + filename + extension;
                        //savepath = Path.Combine(dburl);
                        
                    }
                    
                    sql += "INSERT INTO GrievanceRegistration (Name, EmailID, GrievanceTypeID, GrievanceSubTypeID, GrievanceDetails, GrievanceDocumentURL, GrievanceStatusMasterID, CreatedBy, ForwardedToRoleID, ForwardedDate, ClosedStatus, departmentid) output inserted.ID values ('" + Session["name"].ToString() + "', '" + Session["email"].ToString() + "', '" + drpgrievancetype.SelectedValue + "', '" + drpgrievancesubtype.SelectedValue + "', ";
                    if (txtgrievancedetails.Text != "")
                    {
                        sql += "'" + txtgrievancedetails.Text.Trim() + "',";
                    }
                    else
                    {
                        sql += "NULL,";
                    }
                    if (dburl != "")
                    {
                        sql += "'" + dburl + "',";
                    }
                    else
                    {
                        sql += "NULL,";
                    }
                    sql += " '1', '" + Session["user"].ToString() + "','2', getdate(), '0', '"+ Session["departmentid"].ToString() +"') ";                   
                    res = cc.ScalerReturnString(sql);
                    if (res != "")
                    {
                        id = res;
                        serversavepath = Path.Combine(Server.MapPath("~/" + cc.userdocumentpath), filename + extension);
                        fileupload.SaveAs(serversavepath);
                        if (!File.Exists(serversavepath))
                        {
                            sql = "delete from grievanceregistration where id = '"+ id +"'";
                            res = cc.InsertUpdateDelete(sql);
                            cc.messageweb(this, "Grievance Not Registered");
                            return;
                        }
                        sql = "select grievanceid from grievanceregistration where id = '"+ id +"'";
                        res = cc.ScalerReturnString(sql);

                        Session["userdetail"] = null;
                        //cc.messagewebwithredirect(this, "Your Grievance was successfully registered and your Grievance ID - " + res,"GrievanceRegistration.aspx");
                        cc.messagewebwithredirect(this, "Your Grievance was successfully registered and your Grievance ID - " + res, "../PrintGrievanceConfirmation.aspx?id=" + res);
                        Session["token"] = null;

                    }
                    else
                    {
                        cc.messageweb(this, "Grievance Not Registered");
                        
                    }
                }
            }
            catch (Exception ex)
            {
                cc.messageweb(this, ex.Message.ToString());
            }
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GrievanceRegistration.aspx");
    }
}