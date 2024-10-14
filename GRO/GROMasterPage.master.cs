using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GRO_GROMasterPage : System.Web.UI.MasterPage
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
                if (Session["role"].ToString() != "2")
                {
                    Response.Redirect("../default.aspx", false);
                    return;
                }
                
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
