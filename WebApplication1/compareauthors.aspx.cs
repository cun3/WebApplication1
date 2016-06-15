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
    public partial class compareauthors : System.Web.UI.Page
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
            OracleCommand cmd = new OracleCommand("compare_author", con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter parm = new OracleParameter("authorid1", OracleDbType.NVarchar2);
            parm.Value = txtAuthor1.Text;
            parm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm);

            OracleParameter parm1 = new OracleParameter("authorid2", OracleDbType.NVarchar2);
            parm1.Value = txtAuthor2.Text;
            parm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parm1);

            OracleParameter parm2 = new OracleParameter("author1", OracleDbType.NVarchar2);
            parm2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm2);

            OracleParameter parm3 = new OracleParameter("author2", OracleDbType.NVarchar2);
            parm3.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm3);

            OracleParameter parm4 = new OracleParameter("count1", OracleDbType.Int32);
            parm4.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm4);

            OracleParameter parm5 = new OracleParameter("count2", OracleDbType.Int32);
            parm5.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm5);

            OracleParameter parm6 = new OracleParameter("avg1 ", OracleDbType.Int32);
            parm6.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm6);

            OracleParameter parm7 = new OracleParameter("avg2 ", OracleDbType.Int32);
            parm7.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parm7);


















            string sql = "SELECT AUTHOR_NAME from AUTHOR_TABLE where AUTHOR_ID='" + txtAuthor1.Text + "'";
            string sql1 = "SELECT AUTHOR_NAME from AUTHOR_TABLE where AUTHOR_ID='" + txtAuthor2.Text + "'";
            string sql2 = "SELECT TO_CHAR(AVG(AVG(AVERAGE_RATING)),'99.99') AS AVERAGE FROM RATING_TABLE GROUP BY ISBN HAVING ISBN in (SELECT R.ISBN from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID = A.AUTHOR_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN where B.AUTHOR_ID = '" + txtAuthor1.Text + "')";
            string sql3 = "SELECT TO_CHAR(AVG(AVG(AVERAGE_RATING)),'99.99') AS AVERAGE FROM RATING_TABLE GROUP BY ISBN HAVING ISBN in (SELECT R.ISBN from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID = A.AUTHOR_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN where B.AUTHOR_ID = '" + txtAuthor2.Text + "')";
            string sql4 = "SELECT COUNT(*) AS NOOFBOOKS from BOOK_TABLE GROUP BY AUTHOR_ID HAVING AUTHOR_ID='" + txtAuthor1.Text + "'";
            string sql5 = "SELECT COUNT(*) AS NOOFBOOKS from BOOK_TABLE GROUP BY AUTHOR_ID HAVING AUTHOR_ID='" + txtAuthor2.Text + "'";
            OracleCommand cmd1 = new OracleCommand(sql, con);
            OracleCommand cmd2 = new OracleCommand(sql1, con);
            OracleCommand cmd3 = new OracleCommand(sql2, con);
            OracleCommand cmd4 = new OracleCommand(sql3, con);
            OracleCommand cmd5 = new OracleCommand(sql4, con);
            OracleCommand cmd6 = new OracleCommand(sql5, con);

            cmd.CommandType = CommandType.Text;
            cmd1.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            cmd3.CommandType = CommandType.Text;
            cmd4.CommandType = CommandType.Text;
            cmd5.CommandType = CommandType.Text;
            OracleDataReader dr = cmd1.ExecuteReader();
            OracleDataReader dr1 = cmd2.ExecuteReader();
            OracleDataReader dr2 = cmd3.ExecuteReader();
            OracleDataReader dr3= cmd4.ExecuteReader();
            OracleDataReader dr4 = cmd5.ExecuteReader();
            OracleDataReader dr5 = cmd6.ExecuteReader();
            
            while (dr.Read())
            {
                txtAuthorName1.Text = Convert.ToString(dr["AUTHOR_NAME"]);                                
            }
            while (dr1.Read())
            {
                txtAuthorName2.Text = Convert.ToString(dr1["AUTHOR_NAME"]);
            }
            while (dr2.Read())
            {
                txtrating1.Text = dr2["AVERAGE"] == null || dr2["AVERAGE"] is DBNull ? "" : dr2["AVERAGE"].ToString();
            }
            while (dr3.Read())
            {
                txtrating2.Text = dr3["AVERAGE"] == null || dr3["AVERAGE"] is DBNull ? "" : dr3["AVERAGE"].ToString();
            }
            while (dr4.Read())
            {
                txtbookNo1.Text = Convert.ToString(dr4["NOOFBOOKS"]);
            }
            while (dr5.Read())
            {
                txtbookNo2.Text = Convert.ToString(dr5["NOOFBOOKS"]);
            }

            divResults.Visible = true;
        }
    }
}