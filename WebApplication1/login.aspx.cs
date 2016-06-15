using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace WebApplication1
{
    
    public partial class login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            string username = txtUserId.Text;
            string pwd = txtPassword.Text;

            Session["sessUserName"] = username;

            if(username=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter User Name')", true);
            }
            else if(pwd=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Password.')", true);
            }

            if (username != "" && pwd != "")
            {
                if (ddlRole.SelectedValue=="Publisher")
                {
                    con.Open();
                    string sql = "select * from PUBLISHER_TABLE where PUBLISHER_ID='" + username +  "'";
                    OracleCommand cmd = new OracleCommand(sql, con);

                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();




                    if (dr.HasRows)
                    {
                        Response.Redirect("publisher.aspx");

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong User Name or Password')", true);
                    }

                }
                else if (ddlRole.SelectedValue=="Member")
                {
                    con.Open();


                    string sql = "select * from USER_TABLE where USER_ID=" + username + "and PASSWORD ='" + pwd + "'";
                    OracleCommand cmd = new OracleCommand(sql, con);

                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    dr.Read();




                    if (dr.HasRows)
                    {
                        Response.Redirect("profile.aspx");

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong User Name or Password')", true);
                    }
                }
            }

        }
    }
}