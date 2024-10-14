using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintGrievanceConfirmation : System.Web.UI.Page
{
    ConnectionClass cc = new ConnectionClass();
    Aesenc aes = new Aesenc();
    DataTable dt = new DataTable();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {

            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                string gid = Request.QueryString["id"].ToString();

                sql = "select gr.id, gr.GrievanceId, l.Name, l.Email, gt.CategoryName, gst.SubCategoryName, gr.GrievanceDetails, gr.CreatedOn, l.Department, dm.DepartmentName, gsm.StatusName as gstatus, rm.RoleName as ForwardedTo, gr.GrievanceStatusMasterID, gr.ClosedDate, gr.closedremarks from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID inner join RoleMaster rm on rm.ID = gr.ForwardedToRoleID inner join DepartmentMaster dm on dm.ID = l.Department where gr.GrievanceId = '" + gid + "'";
            }
            dt = cc.FillTable(sql);
            if (dt.Rows.Count > 0)
            {
                lblregistrationdate.Text = Convert.ToDateTime(dt.Rows[0]["createdon"].ToString()).ToString("dd-MM-yyyy");
                lblgrievancenumber.Text = dt.Rows[0]["grievanceid"].ToString();
                lblname.Text = dt.Rows[0]["name"].ToString();
                lbldepartment.Text = dt.Rows[0]["DepartmentName"].ToString();
                lblemail.Text = dt.Rows[0]["email"].ToString();
                lblgrievancetype.Text = dt.Rows[0]["categoryname"].ToString();
                lblgrievancesubtype.Text = dt.Rows[0]["subcategoryname"].ToString();
                lblgrievancedetail.Text = dt.Rows[0]["grievancedetails"].ToString();                
                if (dt.Rows[0]["GrievanceStatusMasterID"].ToString() == "6")
                {
                    divstatusdate.Visible = true;
                    divremarks.Visible = true;
                    divstatus.Visible = true;
                    lblgrievancestatus.Text = dt.Rows[0]["gstatus"].ToString();
                    lblclosingremarks.Text = dt.Rows[0]["closedremarks"].ToString();
                    lblstatusdate.Text = Convert.ToDateTime(dt.Rows[0]["createdon"].ToString()).ToString("dd-MM-yyyy");
                }
                else
                {
                    divstatus.Visible = false;
                    divstatusdate.Visible = false;
                    divremarks.Visible = false;
                }
            }
        }
    }

    protected void btnhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
}