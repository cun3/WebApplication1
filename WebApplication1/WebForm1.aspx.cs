using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Series series = Chart1.Series["Series1"];
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();
            //string sql = "select NAME,MARKS from student";
            string sql ="SELECT ISBN,QUANTITY FROM ORDER_TABLE WHERE ORDER_ID = 'O1'";
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            var dataread = cmd.ExecuteReader();


            while (dataread.Read())
            {
                series.Points.AddXY(dataread["ISBN"].ToString(), dataread["QUANTITY"]);
            }


        }
    }
}