using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace WebApplication1
{
    public partial class profile : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["sessUserName"].ToString();
            

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();
            string sql = "select * from USER_TABLE where USER_ID=" + userName;
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                
                txtUserId.Text = Convert.ToString(dr["USER_ID"]);
                txtLocation.Text = Convert.ToString(dr["LOCATION"]);
                txtAge.Text = Convert.ToString(dr["AGE"]);
                                
            }
            dr.Close();
            dr.Dispose();


        }
    }
}