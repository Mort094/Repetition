using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_testbruger_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM brugere WHERE
                                brugerEmail = @brugerEmail
                                AND brugerPass = @brugerPass";
        cmd.Parameters.AddWithValue("@brugerEmail", "test@test.dk");
        cmd.Parameters.AddWithValue("@brugerPass", "test");

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Session["brugerId"] = reader["brugerId"];


            Response.Redirect("Brugerside.aspx");

        }
        conn.Close();
    }
    protected void btn_admin_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM brugere WHERE
                                brugerEmail = @brugerEmail
                                AND brugerPass = @brugerPass";
        cmd.Parameters.AddWithValue("@brugerEmail", "admin@test.dk");
        cmd.Parameters.AddWithValue("@brugerPass", "1234");

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Session["brugerId"] = reader["brugerId"];


            Response.Redirect("Brugerside.aspx");

        }
        conn.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM brugere WHERE
                                brugerEmail = @brugerEmail
                                AND brugerPass = @brugerPass";

        cmd.Parameters.AddWithValue("@brugerEmail", "test2@test.dk");
        cmd.Parameters.AddWithValue("@brugerPass", "test2");
        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Session["brugerId"] = reader["brugerId"];


            Response.Redirect("Brugerside.aspx");

        }
        conn.Close();
    }
}

  