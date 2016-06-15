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
    public partial class search : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //    BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
            }
        }

        private void BindGrid()
        {
            string isbn = txtISBN.Text;
            string title = txtTitle.Text;
            string genre = txtGenre.Text;
            string author = txtAuthor.Text;
            string publication = txtPublisher.Text;
            int iCheck = 0;


            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();

            string sql = "Select B.ISBN,B.TITLE,B.BOOK_CATEGORY,B.YEAR_OF_PUBLICATION,A.AUTHOR_NAME,P.PUBLICATION_HOUSE_NAME from BOOK_TABLE B JOIN AUTHOR_TABLE A ON B.AUTHOR_ID=A.AUTHOR_ID JOIN PUBLISHER_TABLE P ON B.PUBLISHER_ID=P.PUBLISHER_ID WHERE ";

            if (isbn != "")
            {
                iCheck = 1;
                sql = sql + "B.ISBN='" + isbn + "' AND";
            }
            else if (title != "")
            {
                iCheck = 1;
                sql = sql + "B.TITLE='" + title + "' AND";
            }
            else if (genre != "")
            {
                iCheck = 1;
                sql = sql + "B.BOOK_CATEGORY='" + genre + "' AND";
            }
            else if (author != "")
            {
                iCheck = 1;
                sql = sql + "B.AUTHOR_ID='" + author + "' AND";
            }
            else if (publication != "")
            {
                iCheck = 1;
                sql = sql + "B.PUBLISHER_ID='" + publication + "' AND";
            }

            if (iCheck == 0)
            {
                sql = sql.Substring(0, sql.Length - 6);
            }
            else if (iCheck == 1)
            {
                sql = sql.Substring(0, sql.Length - 3);
            }

            OracleCommand cmd = new OracleCommand(sql, con);

            DataTable table = new DataTable();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
               table.Load(dr);


                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No rows found.')", true);
            }
            

            con.Close();

        }

    }
}