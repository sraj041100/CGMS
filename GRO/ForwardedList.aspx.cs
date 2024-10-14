using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GRO_ForwardedList : System.Web.UI.Page
{
    ConnectionClass cc = new ConnectionClass();
    SqlCommand cmd;
    Aesenc aes = new Aesenc();
    DataTable dt;
    string sql = "";
    string res = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                loaddata();
            }

        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong");
        }
    }

    private void loaddata()
    {

        sql = "select gr.id, gr.GrievanceId, l.Name, l.Email, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDetails, gr.CreatedOn, l.Department, gsm.StatusName as gstatus, rm.RoleName as ForwardedTo from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID inner join RoleMaster rm on rm.ID = gr.ForwardedToRoleID where GrievanceStatusMasterID = '2' and ForwardedToRoleID != '2' and ResolvedStatus is null and ClosedStatus = '0' and ConfirmedStatus is null order by gt.Priority asc, gr.CreatedOn desc";
        dt = cc.FillTable(sql);
        grdgrievancedetails.DataSource = dt;
        grdgrievancedetails.DataBind();
    }

    protected void grdgrievancedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdgrievancedetails.PageIndex = e.NewPageIndex;
        loaddata();

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtgrievanceid.Text != "")
            {
                sql = "select gr.id, gr.GrievanceId, l.Name, l.Email, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDetails, gr.CreatedOn, l.Department, gsm.StatusName as gstatus, rm.RoleName as ForwardedTo from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID inner join RoleMaster rm on rm.ID = gr.ForwardedToRoleID where GrievanceStatusMasterID = '2' and ForwardedToRoleID != '2' and ResolvedStatus is null and ClosedStatus = '0' and ConfirmedStatus is null and grievanceid = '" + txtgrievanceid.Text + "'";
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
}