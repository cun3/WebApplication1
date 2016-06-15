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
    public partial class comparePublication : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            divResults.Visible = false;
        }

        protected void btnCompare_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();
            OracleCommand cmd = new OracleCommand("compare_publisher", con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter parm = new OracleParameter("pubid1",OracleDbType.NVarchar2);
            parm.Value = txtPublisher1.Text;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            OracleParameter parm1 = new OracleParameter("pubid2", OracleDbType.NVarchar2);
            parm1.Value = txtPublisher2.Text;
            parm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm1);

            OracleParameter parm2 = new OracleParameter("pubName1", OracleDbType.NVarchar2);
            parm2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm2);

            OracleParameter parm3 = new OracleParameter("pubName2", OracleDbType.NVarchar2);
            parm3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm3);

            OracleParameter parm4 = new OracleParameter("total1", OracleDbType.Int32);
            parm4.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm4);

            OracleParameter parm5 = new OracleParameter("total2", OracleDbType.Int32);
            parm5.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm5);

            OracleParameter parm6 = new OracleParameter("count1", OracleDbType.Int32);
            parm6.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm6);

            OracleParameter parm7 = new OracleParameter("count2", OracleDbType.Int32);
            parm7.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm7);

           
            string sql = "SELECT PUBLICATION_HOUSE_NAME FROM PUBLISHER_TABLE WHERE PUBLISHER_ID ='" + txtPublisher1.Text + "'";
            string sql1 = "SELECT PUBLICATION_HOUSE_NAME FROM PUBLISHER_TABLE WHERE PUBLISHER_ID ='" + txtPublisher2.Text + "'";

            string sql2 = "SELECT SUM(SUM(QUANTITY)) AS Total_Books from order_table GROUP BY ISBN HAVING ISBN in (SELECT R.ISBN from BOOK_TABLE B JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN where B.PUBLISHER_ID ='" + txtPublisher1.Text + "')";
            string sql3 = "SELECT SUM(SUM(QUANTITY)) AS Total_Books from order_table GROUP BY ISBN HAVING ISBN in (SELECT R.ISBN from BOOK_TABLE B JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN where B.PUBLISHER_ID ='" + txtPublisher2.Text + "')";

            string sql4 = "SELECT COUNT(*) AS NUMBER_OF_BOOKS FROM BOOK_TABLE GROUP BY PUBLISHER_ID HAVING PUBLISHER_ID='" + txtPublisher1.Text + "'";
            string sql5 = "SELECT COUNT(*) AS NUMBER_OF_BOOKS FROM BOOK_TABLE GROUP BY PUBLISHER_ID HAVING PUBLISHER_ID='" + txtPublisher2.Text + "'";

            OracleCommand cmd1 = new OracleCommand(sql, con);
            OracleCommand cmd2 = new OracleCommand(sql1, con);
            OracleCommand cmd3 = new OracleCommand(sql2, con);
            OracleCommand cmd4 = new OracleCommand(sql3, con);
            OracleCommand cmd5 = new OracleCommand(sql4, con);
            OracleCommand cmd6 = new OracleCommand(sql5, con);

            cmd1.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            cmd3.CommandType = CommandType.Text;
            cmd4.CommandType = CommandType.Text;
            cmd5.CommandType = CommandType.Text;
            cmd6.CommandType = CommandType.Text;
            OracleDataReader dr = cmd1.ExecuteReader();
            OracleDataReader dr1 = cmd2.ExecuteReader();
            OracleDataReader dr2 = cmd3.ExecuteReader();
            OracleDataReader dr3 = cmd4.ExecuteReader();
            OracleDataReader dr4 = cmd5.ExecuteReader();
            OracleDataReader dr5 = cmd6.ExecuteReader();

            while (dr.Read())
            {
                txtpublisherName1.Text = Convert.ToString(dr["PUBLICATION_HOUSE_NAME"]);
            }

            while (dr1.Read())
            {
                txtpublisherName2.Text = Convert.ToString(dr1["PUBLICATION_HOUSE_NAME"]);
            }
            while (dr2.Read())
            {
                txttotal1.Text = Convert.ToString(dr2["Total_Books"]);
            }
            while (dr3.Read())
            {
                txttotal2.Text = Convert.ToString(dr3["Total_Books"]);
            }
            while (dr4.Read())
            {
                txtbookNo1.Text = Convert.ToString(dr4["NUMBER_OF_BOOKS"]);
            }
            while (dr5.Read())
            {
                txtbookNo2.Text = Convert.ToString(dr5["NUMBER_OF_BOOKS"]);
            }

            divResults.Visible = true;
        }
    }
}