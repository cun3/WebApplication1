using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class publisher : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["sessUserName"].ToString();


            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();
            string sql = "select * from PUBLISHER_TABLE where PUBLISHER_ID='" + userName +"'";
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtPublisherId.Text = Convert.ToString(dr["PUBLISHER_ID"]);
                txtPubName.Text = Convert.ToString(dr["PUBLICATION_HOUSE_NAME"]);
                

            }
            dr.Close();
            dr.Dispose();


        }

        protected void btnAnalysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("Analysis.aspx");
        }
    }
}