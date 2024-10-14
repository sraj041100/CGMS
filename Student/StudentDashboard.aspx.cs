using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Activities.Expressions;
using System.IO;

public partial class Student_StudentDashboard : System.Web.UI.Page
{
    ConnectionClass cc = new ConnectionClass();
    SqlCommand cmd;
    Aesenc aes = new Aesenc();
    DataTable dt;
    string sql = "";
    string res = "";
    public string districtnames="";
    public string countopendistdata = "";
    public string countclosedistdata = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                sql = "select count(*) from grievanceregistration where createdby = '"+ Session["user"].ToString() +"' and status = '1'";
                res = cc.ScalerReturnString(sql);
                lbltotalgrievance.Text = res;

                sql = "select count(*) from grievanceregistration where createdby = '" + Session["user"].ToString() + "' and status = '1' and closedstatus = '0'";
                res = cc.ScalerReturnString(sql);
                lblopengrievance.Text = res;

                sql = "select count(*) from grievanceregistration where createdby = '" + Session["user"].ToString() + "' and status = '1' and closedstatus = '1'";
                res = cc.ScalerReturnString(sql);
                lblclosedgrievance.Text = res;

                sql = "select gr.GrievanceId, l.Name, l.Email, gt.CategoryName as grievancetype, gst.SubCategoryName as grievancesubtype, gr.GrievanceDetails, gr.CreatedOn, l.Department, gsm.StatusName as gstatus from GrievanceRegistration gr inner join Login l on l.UserID = gr.CreatedBy inner join GrievanceType gt on gt.CategoryID = gr.GrievanceTypeID inner join GrievanceSubType gst on gst.SubCategoryID = gr.GrievanceSubTypeID inner join GrievanceStatusMaster gsm on gsm.ID = gr.GrievanceStatusMasterID where gr.createdby = '" + Session["user"].ToString() + "' order by gt.Priority asc, gr.CreatedOn desc";
                dt = cc.FillTable(sql);
                grdgrievancedetails.DataSource = dt;
                grdgrievancedetails.DataBind();
            }

        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong");
        }
    }


    protected void grdgrievancedetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "print")
        {
            Response.Redirect("~/PrintGrievanceConfirmation.aspx?id=" + id,false);
        }
        if (e.CommandName == "view")
        {

            sql = "select GrievanceDocumentURL from grievanceregistration where grievanceid = '" + id + "'";
            res = cc.ScalerReturnString(sql);
            Response.Redirect(cc.directorypath + res,false);
        }
    }
}