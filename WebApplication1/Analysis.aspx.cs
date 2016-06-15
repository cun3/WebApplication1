using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Analysis : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            divResults.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = Session["sessUserName"].ToString();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();
            Series series = Chart1.Series["Series1"];
            if (ddlOptions.SelectedValue=="0")
            {
                
                string sql = "select YEAR_OF_PUBLICATION, count(ISBN) AS Total from book_table B JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID  where YEAR_OF_PUBLICATION >='" + txtYear.Text + "' and YEAR_OF_PUBLICATION <='" + txtToYear.Text + "' AND B.PUBLISHER_ID = '" + userName + "' group by YEAR_OF_PUBLICATION order by YEAR_OF_PUBLICATION";
                
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    series.Points.AddXY(dr["YEAR_OF_PUBLICATION"].ToString(), dr["Total"]);
                }
                dr.Close();
                }
            else if (ddlOptions.SelectedValue == "1")
            {
                string sql = "select EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) as YEAR,SUM(S.QUANTITY) AS SALES from ORDER_TABLE S join book_table b on s.isbn = b.isbn where EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) >='" +txtYear.Text + "'AND EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) <='" +txtToYear.Text+ "'AND B.PUBLISHER_ID = '" + userName + "' GROUP BY EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) ORDER BY EXTRACT(YEAR FROM S.DATE_OF_PURCHASE)";
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.CommandType = CommandType.Text;
                OracleDataReader dr1 = cmd.ExecuteReader();

                while (dr1.Read())
                {
                    series.Points.AddXY(dr1["YEAR"].ToString(), dr1["SALES"]);
                }
                dr1.Close();
            }
            else if(ddlOptions.SelectedValue=="2")
            {
                string sql = "select EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) as YEAR,COUNT(S.ORDER_ID) AS SALES from ORDER_TABLE S join book_table b on s.isbn = b.isbn where EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) >='" + txtYear.Text + "'AND EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) <='" + txtToYear.Text + "'AND B.PUBLISHER_ID = '" + userName + "' GROUP BY EXTRACT(YEAR FROM S.DATE_OF_PURCHASE) ORDER BY EXTRACT(YEAR FROM S.DATE_OF_PURCHASE)";
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.CommandType = CommandType.Text;
                OracleDataReader dr2 = cmd.ExecuteReader();

                while (dr2.Read())
                {
                    series.Points.AddXY(dr2["YEAR"].ToString(), dr2["SALES"]);
                }
                dr2.Close();
            }
            divResults.Visible = true;
        }
    }
}