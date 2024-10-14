using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string key = "123456";
    ConnectionClass cc = new ConnectionClass();
    Aesenc aes = new Aesenc();
    DataTable dt;
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        try
        {
            if (!IsPostBack)
            {

                if (Session["role"] != null)
                {
                    if (Session["role"].ToString() == "1")
                    {
                        Response.Redirect("Admin/AdminDashboard.aspx", false);
                    }
                    if (Session["role"].ToString() == "2")
                    {
                        Response.Redirect("GRO/GRODashboard.aspx", false);
                    }
                    if (Session["role"].ToString() == "3")
                    {
                        Response.Redirect("Student/StudentDashboard.aspx", false);
                    }
                    if (Session["role"].ToString() == "6")
                    {
                        Response.Redirect("Principal/PrincipalDashboard.aspx", false);
                    }
                    if (Session["role"].ToString() == "7")
                    {
                        Response.Redirect("VP/VPDashboard.aspx", false);
                    }
                    if (Session["role"].ToString() == "8")
                    {
                        Response.Redirect("ICC/ICCDashboard.aspx", false);
                    }
                    if (Session["role"].ToString() == "9")
                    {
                        Response.Redirect("HOD/HODDashboard.aspx", false);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Invalid Login");
        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["captcha"].ToString() == txtcaptcha.Text)
            //if (true)
            {


                string plainkey = "123456";
                plainkey = plainkey + plainkey + plainkey + plainkey;
                plainkey = plainkey.Substring(0, 16);
                string plainpassword = aes.decryptionfromjavascript(txtpassword.Text, plainkey, plainkey);

                cc.con.Open();
                sql = "select l.ID, l.Name, l.Email, l.UserID, l.RoleID, l.Status, dm.DepartmentName as department, l.Department as departmentid from login l left join DepartmentMaster dm on dm.ID = l.Department where userid=@user and password = @pass and l.status = '1'";
                SqlCommand cmd = new SqlCommand(sql, cc.con);
                cmd.Parameters.AddWithValue("@user", txtusername.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", plainpassword);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["user"] = dt.Rows[0]["userid"].ToString();
                    Session["role"] = dt.Rows[0]["roleid"].ToString();
                    Session["loginid"] = dt.Rows[0]["id"].ToString();
                    Session["name"] = dt.Rows[0]["name"].ToString();
                    Session["email"] = dt.Rows[0]["email"].ToString();
                    Session["department"] = dt.Rows[0]["department"].ToString();
                    Session["departmentid"] = dt.Rows[0]["departmentid"].ToString();

                    if (dt.Rows[0]["RoleID"].ToString() == "1")
                    {
                        Response.Redirect("Admin/AdminDashboard.aspx", false);
                    }
                    if (dt.Rows[0]["RoleID"].ToString() == "2")
                    {
                        Response.Redirect("GRO/GRODashboard.aspx", false);
                    }
                    if (dt.Rows[0]["RoleID"].ToString() == "3")
                    {
                        Response.Redirect("Student/StudentDashboard.aspx", false);
                    }
                    if (dt.Rows[0]["RoleID"].ToString() == "6")
                    {
                        Response.Redirect("Principal/PrincipalDashboard.aspx", false);
                    }
                    if (dt.Rows[0]["RoleID"].ToString() == "7")
                    {
                        Response.Redirect("VP/VPDashboard.aspx", false);
                    }
                    if (dt.Rows[0]["RoleID"].ToString() == "8")
                    {
                        Response.Redirect("ICC/ICCDashboard.aspx", false);
                    }
                    if (dt.Rows[0]["RoleID"].ToString() == "9")
                    {
                        Response.Redirect("HOD/HODDashboard.aspx", false);
                    }
                }
                else
                {
                    cc.messageweb(this, "Incorrect Username and/or Password and/or User is not Active.");
                }
            }
            else
            {
                cc.messageweb(this, "Incorrect Captcha");
            }
        }
        catch (Exception ex)
        {
            cc.messageweb(this, "Something Went Wrong.");
        }
    }
}