using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_StudentMasterPage : System.Web.UI.MasterPage
{
    ConnectionClass cc = new ConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (cc.CheckSession() == "")
                {
                    Response.Redirect("../default.aspx", false);
                    return;
                }
                if (Session["role"].ToString() != "3")
                {
                    Response.Redirect("../default.aspx", false);
                    return;
                }
                lblloginname.Text = Session["name"].ToString();
                lbldepartment.Text = Session["department"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../default.aspx", false);
        }
    }

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../default.aspx");
    }
}
