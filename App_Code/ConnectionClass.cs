using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.Linq;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class ConnectionClass
{
    public SqlConnection con;
    
    public string date = DateTime.Now.ToString("yyyy-MM-dd");
    public string time = DateTime.Now.ToString("hh:mm:ss tt");
    public string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    public string directorypath = "http://localhost:50803/";
    //public string directorypath = "http://cgms.shivamraj.in/";

    public string resolvedocumentpath = "Documents/Resolved_Documents/";
    public string userdocumentpath = "Documents/User_Documents/";

    public ConnectionClass()
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);	      
        }
        catch
        {
        }
    }

    public string CheckSession()
    {
        if ((HttpContext.Current.Session["loginid"] == null) || (HttpContext.Current.Session["loginid"].ToString() == ""))
        {
            return "";
        }
        else
        {
            return "1";
        }
    }

    public string CRUD(string strSql, params SqlParameter[] parameters)
    {
        int res=0;
        try
        {
            con.Open();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = strSql;
            SqlCmd.Connection = con;
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    SqlCmd.Parameters.Add(parameters[i]);
                }
            }
            res = SqlCmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            if (res > 0)
            {
                return "SUSS";
            }
            else
            {
                return "";
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }                
    }

    public string GetIp()
    {
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return ip;
    }

    public string GetpublicIp()
    {
        string VisitorsIPAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
        {
            VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
        }
        return VisitorsIPAddr;
    }

    public string GetMAC()
    {
        String firstMacAddress = NetworkInterface
    .GetAllNetworkInterfaces()
    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    .Select(nic => nic.GetPhysicalAddress().ToString())
    .FirstOrDefault();
        return firstMacAddress;
    }

    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("");
    }

    public string InsertUpdateDelete(string query)
    {
        SqlCommand com = new SqlCommand(query, con);
        try
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            com.CommandTimeout = 0;
            int i = com.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            if (i > 0)
            {
                return "SUSS";
            }
            else
            {
                return "";
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    public string ScalerReturnString(string QueryString)
    {
        string Value;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }
        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        try
        {
            if (ob == null)
            {
                Value = "";
            }
            else
            {
                Value = ob.ToString();
            }
            return ( Value );
        }
        catch (Exception e)
        {
            Value = "";
            return ( Value );
        }

    }

    public int ScalerReturnInt(string QueryString)
    {
        int Value;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }

        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        if (ob == null)
        {
            Value = 0;
        }
        else
        {
            try
            {
                Value = int.Parse(ob.ToString());
            }
            catch
            {
                Value = 0;
            }
        }
        return ( Value );


    }

    public DataTable FillTable(string query)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = query;
            com.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            { con.Open(); }

            SqlDataAdapter da = new SqlDataAdapter(com);
            using (da)
            {
                da.Fill(dt);
            }
            if (con.State == ConnectionState.Open)
            { con.Close(); }
        }
        catch (Exception ex)
        {
            dt = null;
        }
        return dt;

    }

    public void filldropdownlist(string columnname, DataTable datatablename, DropDownList dropdownlistsname)
    {
        dropdownlistsname.Items.Clear();
        for (int i = 0; i < datatablename.Rows.Count; i++)
        {
            dropdownlistsname.Items.Add(datatablename.Rows[i][columnname].ToString());
        }
        dropdownlistsname.Items.Insert(0, "Select");
    }    

    public void messageweb(Page p, string message)
    {
        ScriptManager.RegisterStartupScript(p, GetType(), "alert", "alert('" + message + "')", true);
    }

    public void messagewebwithredirect(Page p, string message, string url)
    {
        ScriptManager.RegisterStartupScript(p, GetType(), "alert", "alert('" + message + "');window.open('" + url + "', '_self');", true);
    }

    public void multiplemessageweb(Page p, string message)
    {
        string jfunction = "var arr = '" + message + "'.split('-');for (let i = 0; i < arr.length; i++){if (arr[i] != ''){alert(arr[i]);}}";
        ScriptManager.RegisterClientScriptBlock(p, p.GetType(), "alert", jfunction, true);
    }

    public string sendmail(string toemail, string subject, string body)
    {
        try
        {
            string senderemail = "";
            string senderpassword = "";
            MailMessage msg = new MailMessage(senderemail, toemail, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                     
            client.Credentials = new NetworkCredential(senderemail, senderpassword);
            
            client.EnableSsl = true;
            client.Send(msg);
            return "SUSS";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }

    }

    public string rndnumber()
    {
        string x = "";
        Random ran = new Random();

        String b = "abcdefghijklmnpqrstuvwxyz";
        string c = "123456789";
        for (int i = 0; i < 6; i++)
        {
            int a = ran.Next(9);
            x = x + b.ElementAt(a) + c.ElementAt(a);
        }
        return x;
    }

    public bool ScalerReturnBool(string QueryString)
    {
        bool Value;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }

        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        if (ob == null)
        {
            Value = false;
        }
        else
        {
            try
            {
                Value = bool.Parse(ob.ToString());
            }
            catch
            {
                Value = false;
            }
        }
        return (Value);
    }

    public double ScalerReturnDouble(string QueryString)
    {
        double Value;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }
        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        if (ob == null)
        {
            Value = 0;
        }
        else
        {
            Value = double.Parse(ob.ToString());
        }
        return (Value);
    }

    public float ScalerReturnFloat(string QueryString)
    {
        float Value;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }
        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        if (ob == null)
        {
            Value = 0;
        }
        else
        {
            Value = float.Parse(ob.ToString());
        }
        return (Value);
    }

    public DateTime ScalerReturnDateTime(string QueryString)
    {
        string date = "08/15/2047";
        DateTime Value = DateTime.Now;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }
        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        if (ob == DBNull.Value)
        {
            //Value = DateTime.Parse(date.ToString());
        }
        else
        {
            Value = DateTime.Parse(ob.ToString());
        }
        return Value;
    }

    public TimeSpan ScalerReturnTimeSpan(string QueryString)
    {
        string date = "24:00";
        TimeSpan Value = DateTime.Now.TimeOfDay;
        SqlCommand cmd = new SqlCommand(QueryString, con);
        if (con.State == ConnectionState.Closed)
        { con.Open(); }
        object ob = cmd.ExecuteScalar();
        if (con.State == ConnectionState.Open)
        { con.Close(); }
        if (ob == DBNull.Value)
        {
            //Value = DateTime.Parse(date.ToString());
        }
        else
        {
            Value = TimeSpan.Parse(ob.ToString());
        }
        return Value;
    }    

}

