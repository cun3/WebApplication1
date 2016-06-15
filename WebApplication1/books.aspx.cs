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
    public partial class books : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string isbn=Request.QueryString["code"];
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();

            string sql = "SELECT distinct B.TITLE,B.BOOK_CATEGORY,B.ISBN,A.AUTHOR_NAME,P.PUBLICATION_HOUSE_NAME,B.YEAR_OF_PUBLICATION,(SELECT TO_CHAR((AVG(AVERAGE_RATING)),'99.99') FROM RATING_TABLE GROUP BY ISBN HAVING ISBN = '" + isbn + "') AS AVERAGE from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID = A.AUTHOR_ID JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN WHERE B.ISBN = '" + isbn + "'";
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtBook.Text = Convert.ToString(dr["TITLE"]);
                txtGenre.Text = Convert.ToString(dr["BOOK_CATEGORY"]);
                txtISBN.Text = Convert.ToString(dr["ISBN"]);
                txtAuthor.Text = Convert.ToString(dr["AUTHOR_NAME"]);
                txtPublisher.Text = Convert.ToString(dr["PUBLICATION_HOUSE_NAME"]);
                txtyop.Text = Convert.ToString(dr["YEAR_OF_PUBLICATION"]);
                txtRating.Text = dr["AVERAGE"] == null || dr["AVERAGE"] is DBNull ? "" : dr["AVERAGE"].ToString();
                //txtRating.Text=(string)dr["AVERAGE"];
            }
        dr.Close();

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string userName = Session["sessUserName"].ToString();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();

            string sql = "INSERT INTO ORDER_TABLE VALUES ('O63892','" + txtISBN.Text + "'," + txtQuantity.Text + "," + userName + ",SYSDATE)";
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Book Ordered')", true);
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
            string userName = Session["sessUserName"].ToString();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();
            string isbn = txtISBN.Text;

            string sql = "INSERT INTO RATING_TABLE VALUES ('" + isbn + "'," + txtRate.Text + "," + userName + ")";
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            string sql1 = "SELECT (SELECT TO_CHAR((AVG(AVERAGE_RATING)),'99.99') FROM RATING_TABLE GROUP BY ISBN HAVING ISBN = '" + isbn + "') AS AVERAGE from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID = A.AUTHOR_ID JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID = P.PUBLISHER_ID JOIN RATING_TABLE R ON B.ISBN = R.ISBN WHERE B.ISBN = '" + isbn + "'";

            OracleCommand cmd1 = new OracleCommand(sql1, con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                txtRating.Text = dr1["AVERAGE"] == null || dr1["AVERAGE"] is DBNull ? "" : dr1["AVERAGE"].ToString();
            }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Book Rated')", true);
        }
    }
}