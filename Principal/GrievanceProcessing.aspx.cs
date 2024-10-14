using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal_GrievanceProcessing : System.Web.UI.Page
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
        try
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    view(id);
                }
                else
                {
                    Response.Redirect("PrincipalDashboard.aspx");
                }

            }
        }
        catch (Exception ex)
        {
            Response.Redirect("PrincipalDashboard.aspx");
        }
    }

    private void view(string id)
    {
        sql = "SELECT gr.id, gr.GrievanceId, gr.Name, gr.EmailID, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDocumentURL, gr.GrievanceDetails, l.UserID, l.Department, dm.RoleID FROM GrievanceRegistration gr left join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID left join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID left join Login l on l.UserID = gr.CreatedBy left join DepartmentMaster dm on dm.ID = l.Department where gr.Id = '" + id + "' and GrievanceStatusMasterID = '2' and ForwardedToRoleID = '6' and ResolvedStatus is null and ClosedStatus = '0'";
        dt = cc.FillTable(sql);
        ViewState["grddata"] = dt;
        if (dt != null)
        {
            lblgrievanceid.Text = dt.Rows[0]["GrievanceId"].ToString();
            lblname.Text = dt.Rows[0]["name"].ToString();
            lblemail.Text = dt.Rows[0]["emailid"].ToString();
            lblgrievancetype.Text = dt.Rows[0]["grievancetype"].ToString();
            lblgrievancesubtype.Text = dt.Rows[0]["grievancesubtype"].ToString();
            lblgrievancedetails.Text = dt.Rows[0]["grievancedetails"].ToString();            
            txtdocumenturl.Value = dt.Rows[0]["GrievanceDocumentURL"].ToString();
        }
        else
        {
            Response.Redirect("PrincipalDashboard.aspx");
        }
    }

    protected void btngrievancedocument_Click(object sender, EventArgs e)
    {
        if (txtdocumenturl.Value != "")
        {
            Response.Redirect(cc.directorypath + txtdocumenturl.Value, false);
        }
        else
        {
            cc.messageweb(this, "No Document Uploaded");
        }
    }

    private string validateeverything()
    {
        if (txtremarks.Text == "")
        {
            return ("Remarks Cannot Be Blank");
        }

        //-------------------------------------------------------------

        if (txtremarks.Text.Trim() != "")
        {
            r = new Regex(@"^([a-zA-Z0-9,]+\s)*[a-zA-Z0-9,]+$");
            if (!r.IsMatch(txtremarks.Text))
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

    public string fileID()
    {
        return Guid.NewGuid().ToString("N");
    }

    protected void btnclose_Click(object sender, EventArgs e)
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
                if (fileupload.HasFile)
                {
                    extension = Path.GetExtension(fileupload.FileName);
                    filename = fileID();
                    dburl = cc.userdocumentpath + filename + extension;
                    if (dburl == "")
                    {
                        dburl = " NULL ";
                    }
                    else
                    {
                        dburl = "'" + dburl + "'";
                    }
                    //savepath = Path.Combine(dburl);

                }
                sql = "update GrievanceRegistration set GrievanceStatusMasterID = '6', ForwardedToRoleID = '2', ForwardedFromRoleID = '6', ClosedStatus = '1', ClosedByUserID = '" + Session["user"].ToString() + "', ClosedRemarks = '" + txtremarks.Text.Trim() + "', ClosedDate = getdate(), resolvedstatus = '1', resolvedbyuserid = '" + Session["user"].ToString() + "', resolvedremarks = '" + txtremarks.Text.Trim() + "', resolveddocumenturl = "+ dburl +", resolveddate = getdate() where GrievanceId = '" + lblgrievanceid.Text + "'";
                res = cc.InsertUpdateDelete(sql);
                if (res == "SUSS")
                {
                    serversavepath = Path.Combine(Server.MapPath("~/" + cc.userdocumentpath), filename + extension);
                    fileupload.SaveAs(serversavepath);
                    if (!File.Exists(serversavepath))
                    {
                        sql = "update GrievanceRegistration set GrievanceStatusMasterID = '2', ForwardedToRoleID = '6', ForwardedFromRoleID = '2', ClosedStatus = '0', ClosedByUserID = NULL , ClosedRemarks = NULL, ClosedDate = NULL, resolvedstatus = NULL, resolvedbyuserid = NULL, resolvedremarks = NULL, resolveddocumenturl = NULL, resolveddate = NULL where GrievanceId = '" + lblgrievanceid.Text + "'";
                        res = cc.InsertUpdateDelete(sql);
                        cc.messageweb(this, "Grievance File Upload Failed, Hence Closing Failed");
                        return;
                    }
                    cc.messagewebwithredirect(this, "Closed Successfully", "PrincipalDashboard.aspx");

                }
                else
                {
                    cc.messageweb(this, "Closing Failed for Grievance ID - " + lblgrievanceid.Text);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

}