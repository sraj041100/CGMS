using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VP_VPDashboard : System.Web.UI.Page
{
    ConnectionClass cc = new ConnectionClass();
    SqlCommand cmd;
    DataTable dt;
    string sql = "";
    string res = "";
    public string districtnames = "";
    public string countopendistdata = "";
    public string countclosedistdata = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                sql = "select count(id) from grievanceregistration where status = '1' and ForwardedToRoleID = '7' ";
                res = cc.ScalerReturnString(sql);
                lbltotalgrievance.Text = res;

                sql = "select count(id) from grievanceregistration where status = '1' and ClosedStatus = '0' and ForwardedToRoleID = '7' ";
                res = cc.ScalerReturnString(sql);
                lblopengrievance.Text = res;

                sql = "select count(id) from grievanceregistration where status = '1' and ClosedStatus = '1' and ForwardedToRoleID = '7' ";
                res = cc.ScalerReturnString(sql);
                lblclosedgrievance.Text = res;

                loaddata();
                loadgrievancetype();
            }

        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong");
        }
    }

    private void loaddata()
    {

        sql = "select gr.id, gr.GrievanceId, l.Name, l.Email, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDetails, gr.CreatedOn, l.Department, gsm.StatusName as gstatus from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID where GrievanceStatusMasterID = '2' and ForwardedToRoleID = '7' and ResolvedStatus is null and ClosedStatus = '0' order by gt.Priority asc, gr.CreatedOn desc";
        dt = cc.FillTable(sql);
        grdgrievancedetails.DataSource = dt;
        grdgrievancedetails.DataBind();

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

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtgrievanceid.Text != "")
            {
                sql = "select gr.id, gr.GrievanceId, l.Name, l.Email, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDetails, gr.CreatedOn, l.Department, gsm.StatusName as gstatus from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID where grievanceid = '" + txtgrievanceid.Text + "' and GrievanceStatusMasterID = '2' and ForwardedToRoleID = '7' and ResolvedStatus is null and ClosedStatus = '0' ";
                dt = cc.FillTable(sql);
                if (dt.Rows.Count > 0)
                {
                    grdgrievancedetails.DataSource = dt;
                    grdgrievancedetails.DataBind();                    
                }
                else
                {
                    cc.messageweb(this, "Grievance ID Not Found");
                    loaddata();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnrefresh_Click(object sender, EventArgs e)
    {
        loaddata();
    }

    protected void grdgrievancedetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "ed")
        {
            Response.Redirect("GrievanceProcessing.aspx?id=" + id);
        }
    }

    protected void grdgrievancedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdgrievancedetails.PageIndex = e.NewPageIndex;
        loaddata();

    }

    protected void drpgrievancetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpgrievancetype.SelectedIndex > 0)
            {
                sql = "select gr.id, gr.GrievanceId, l.Name, l.Email, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDetails, gr.CreatedOn, l.Department, gsm.StatusName as gstatus from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID where GrievanceStatusMasterID = '2' and ForwardedToRoleID = '7' and ResolvedStatus is null and ClosedStatus = '0' and gr.GrievanceTypeID = '" + drpgrievancetype.SelectedValue + "' order by gt.Priority asc, gr.CreatedOn desc";
                dt = cc.FillTable(sql);
                grdgrievancedetails.DataSource = dt;
                grdgrievancedetails.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
}