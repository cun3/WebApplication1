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
    public partial class count : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCount_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;

            con.Open();

            string sql = "SELECT COUNT(*) FROM USER_TABLE";
            string sql1 = "SELECT COUNT(*) FROM book_table";
            string sql2 = "SELECT COUNT(*) FROM author_table";
            string sql3 = "SELECT COUNT(*) FROM publisher_table";
            string sql4 = "SELECT COUNT(*) FROM order_table";
            string sql5 = "SELECT COUNT(*) FROM rating_table";
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
                txtUser.Text = Convert.ToString(dr["COUNT(*)"]);
            }

            while (dr1.Read())
            {
                txtBook.Text = Convert.ToString(dr1["COUNT(*)"]);
            }
            while (dr2.Read())
            {
                txtAuthor.Text = Convert.ToString(dr2["COUNT(*)"]);
            }
            while (dr3.Read())
            {
                txtPublisher.Text = Convert.ToString(dr3["COUNT(*)"]);
            }
            while (dr4.Read())
            {
                txtOrder.Text = Convert.ToString(dr4["COUNT(*)"]);
            }
            while (dr5.Read())
            {
                txtRating.Text = Convert.ToString(dr5["COUNT(*)"]);
            }

        }
    }
}