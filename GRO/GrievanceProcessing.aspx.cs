using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GRO_GrievanceProcessing : System.Web.UI.Page
{
    ConnectionClass cc = new ConnectionClass();    
    DataTable dt = new DataTable();
    string sql = "";
    string res = "";
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
                    Response.Redirect("GRODashboard.aspx");
                }

            }
        }
        catch (Exception ex)
        {
            Response.Redirect("GRODashboard.aspx");
        }
    }

    private void view(string id)
    {
        sql = "SELECT gr.id, gr.GrievanceId, gr.Name, gr.EmailID, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDocumentURL, gr.GrievanceDetails, l.UserID, l.Department, dm.RoleID FROM GrievanceRegistration gr left join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID left join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID left join Login l on l.UserID = gr.CreatedBy left join DepartmentMaster dm on dm.ID = l.Department where gr.Id = '" + id + "'";
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
            Response.Redirect("GRODashboard.aspx");
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

    protected void btnclose_Click(object sender, EventArgs e)
    {
        sql = "update GrievanceRegistration set GrievanceStatusMasterID = '6', ForwardedToRoleID = '2', ForwardedFromRoleID = '2', ClosedStatus = '1', ClosedByUserID = '" + Session["user"].ToString() + "', ClosedRemarks = 'Irrelevant Grievance', ClosedDate = getdate(), resolvedstatus = '1', resolvedbyuserid = '" + Session["user"].ToString() + "', resolvedremarks = 'Irrelevant Grievance', resolveddocumenturl = NULL, resolveddate = getdate() where GrievanceId = '" + lblgrievanceid.Text + "'";
        res = cc.InsertUpdateDelete(sql);
        if (res == "SUSS")
        {
            cc.messagewebwithredirect(this, "Closed Successfully", "GRODashboard.aspx");

        }
        else
        {
            cc.messageweb(this, "Closing Failed for Grievance ID - " + lblgrievanceid.Text);
        }
    }



    protected void btnforwardtohod_Click(object sender, EventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["grddata"];
            sql = "update GrievanceRegistration set GrievanceStatusMasterID = '2', ForwardedToRoleID = '"+ dt.Rows[0]["roleid"].ToString() +"', ForwardedFromRoleID = '2' where GrievanceId = '" + lblgrievanceid.Text + "'";
            res = cc.InsertUpdateDelete(sql);
            if (res == "SUSS")
            {
                cc.messagewebwithredirect(this, "Forwarded Successfully", "GRODashboard.aspx");

            }
            else
            {
                cc.messageweb(this, "Fowrwarding Failed for Grievance ID - " + lblgrievanceid.Text);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnforwardtoicc_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "update GrievanceRegistration set GrievanceStatusMasterID = '2', ForwardedToRoleID = '8', ForwardedFromRoleID = '2' where GrievanceId = '" + lblgrievanceid.Text + "'";
            res = cc.InsertUpdateDelete(sql);
            if (res == "SUSS")
            {
                cc.messagewebwithredirect(this, "Forwarded Successfully", "GRODashboard.aspx");

            }
            else
            {
                cc.messageweb(this, "Fowrwarding Failed for Grievance ID - " + lblgrievanceid.Text);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnforwardtoviceprincipal_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "update GrievanceRegistration set GrievanceStatusMasterID = '2', ForwardedToRoleID = '7', ForwardedFromRoleID = '2' where GrievanceId = '" + lblgrievanceid.Text + "'";
            res = cc.InsertUpdateDelete(sql);
            if (res == "SUSS")
            {
                cc.messagewebwithredirect(this, "Forwarded Successfully", "GRODashboard.aspx");

            }
            else
            {
                cc.messageweb(this, "Fowrwarding Failed for Grievance ID - " + lblgrievanceid.Text);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnforwardtoprincipal_Click(object sender, EventArgs e)
    {
        try
        {
            sql = "update GrievanceRegistration set GrievanceStatusMasterID = '2', ForwardedToRoleID = '6', ForwardedFromRoleID = '2' where GrievanceId = '" + lblgrievanceid.Text + "'";
            res = cc.InsertUpdateDelete(sql);
            if (res == "SUSS")
            {
                cc.messagewebwithredirect(this, "Forwarded Successfully", "GRODashboard.aspx");

            }
            else
            {
                cc.messageweb(this, "Fowrwarding Failed for Grievance ID - " + lblgrievanceid.Text);
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}