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
    public partial class compareBooks : System.Web.UI.Page
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

            OracleCommand cmd = new OracleCommand("compare_book", con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter parm = new OracleParameter("bookid1", OracleDbType.NVarchar2);
            parm.Value = txtBook1.Text;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            OracleParameter parm1 = new OracleParameter("bookid2", OracleDbType.NVarchar2);
            parm1.Value = txtBook2.Text;
            parm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm1);

            OracleParameter parm2 = new OracleParameter("title1", OracleDbType.NVarchar2);
            parm2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm2);

            OracleParameter parm3 = new OracleParameter("title2", OracleDbType.NVarchar2);
            parm3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm3);

            OracleParameter parm4 = new OracleParameter("author1", OracleDbType.Int32);
            parm4.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm4);

            OracleParameter parm5 = new OracleParameter("author2", OracleDbType.Int32);
            parm5.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm5);

            OracleParameter parm6 = new OracleParameter("pubname1", OracleDbType.Int32);
            parm6.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm6);

            OracleParameter parm7 = new OracleParameter("pubname2", OracleDbType.Int32);
            parm7.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm7);

            OracleParameter parm8 = new OracleParameter("yop1", OracleDbType.Int32);
            parm8.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm8);

            OracleParameter parm9 = new OracleParameter("yop2", OracleDbType.Int32);
            parm9.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm9);

            OracleParameter parm10 = new OracleParameter("avg1", OracleDbType.Int32);
            parm10.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm10);

            OracleParameter parm11 = new OracleParameter("avg2", OracleDbType.Int32);
            parm11.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm11);



            string sql = "SELECT distinct B.TITLE,A.AUTHOR_NAME,P.PUBLICATION_HOUSE_NAME,B.YEAR_OF_PUBLICATION,(SELECT TO_CHAR((AVG(AVERAGE_RATING)),'99.99') FROM RATING_TABLE GROUP BY ISBN HAVING ISBN = '" + txtBook1.Text + "') AS AVERAGE from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID = A.AUTHOR_ID JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN WHERE B.ISBN = '" + txtBook1.Text + "'";
            OracleCommand cmd1 = new OracleCommand(sql, con);

            cmd1.CommandType = CommandType.Text;
            OracleDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                txtTitle1.Text = Convert.ToString(dr["TITLE"]);
                
                txtAuthor1.Text = Convert.ToString(dr["AUTHOR_NAME"]);
                txtPublisher1.Text = Convert.ToString(dr["PUBLICATION_HOUSE_NAME"]);
                txtyop1.Text = Convert.ToString(dr["YEAR_OF_PUBLICATION"]);
                txtrate1.Text = dr["AVERAGE"] == null || dr["AVERAGE"] is DBNull ? "" : dr["AVERAGE"].ToString();
                //txtRating.Text=(string)dr["AVERAGE"];
            }
            dr.Close();

            string sql1 = "SELECT distinct B.TITLE,A.AUTHOR_NAME,P.PUBLICATION_HOUSE_NAME,B.YEAR_OF_PUBLICATION,(SELECT TO_CHAR((AVG(AVERAGE_RATING)),'99.99') FROM RATING_TABLE GROUP BY ISBN HAVING ISBN = '" + txtBook2.Text + "') AS AVERAGE from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID = A.AUTHOR_ID JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN WHERE B.ISBN = '" + txtBook2.Text + "'";
            OracleCommand cmd2 = new OracleCommand(sql1, con);

            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd2.ExecuteReader();

            while (dr1.Read())
            {
                txtTitle2.Text = Convert.ToString(dr1["TITLE"]);

                txtAuthor2.Text = Convert.ToString(dr1["AUTHOR_NAME"]);
                txtPublisher2.Text = Convert.ToString(dr1["PUBLICATION_HOUSE_NAME"]);
                txtyop2.Text = Convert.ToString(dr1["YEAR_OF_PUBLICATION"]);
                txtrate2.Text = dr1["AVERAGE"] == null || dr1["AVERAGE"] is DBNull ? "" : dr1["AVERAGE"].ToString();
                //txtRating.Text=(string)dr["AVERAGE"];
            }
            dr1.Close();
            divResults.Visible = true;


        }
    }
}