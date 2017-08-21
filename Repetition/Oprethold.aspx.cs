using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Oprethold : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT * FROM alder", conn);

            conn.Open();
            dd_alder.DataSource = cmd.ExecuteReader();
            dd_alder.DataBind();
            dd_alder.Items.Insert(0, new ListItem("Vælg", ""));
            conn.Close();

            cmd = new SqlCommand("SELECT * FROM niveau", conn);

            conn.Open();
            dd_niveau.DataSource = cmd.ExecuteReader();
            dd_niveau.DataBind();
            dd_niveau.Items.Insert(0, new ListItem("Vælg", ""));
            conn.Close();

            cmd = new SqlCommand("SELECT * FROM instruktor", conn);

            conn.Open();
            dd_instructor.DataSource = cmd.ExecuteReader();
            dd_instructor.DataBind();
            dd_instructor.Items.Insert(0, new ListItem("Vælg", ""));
            conn.Close();

            cmd = new SqlCommand("SELECT * FROM stilart", conn);

            conn.Open();
            dd_stilart.DataSource = cmd.ExecuteReader();
            dd_stilart.DataBind();
            dd_stilart.Items.Insert(0, new ListItem("Vælg", ""));
            conn.Close();
        }
    }

    protected void btn_opretHold_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO hold (holdNavn, holdBeskr, FK_instruktorId, FK_stilartId, FK_alderId, FK_niveauId, holdFoto) VALUES (@holdNavn, @holdBeskr, @FK_instruktorId, @FK_stilartId, @FK_alderId, @FK_niveauId, @holdFoto) ";

        cmd.Parameters.AddWithValue("@holdNavn", tb_navn.Text);
        cmd.Parameters.AddWithValue("@holdBeskr", tb_beskri.Text);
        cmd.Parameters.AddWithValue("@FK_instruktorId", dd_instructor.SelectedValue);
        cmd.Parameters.AddWithValue("@FK_stilartId", dd_stilart.SelectedValue);
        cmd.Parameters.AddWithValue("@FK_alderId", dd_alder.SelectedValue);
        cmd.Parameters.AddWithValue("@FK_niveauId", dd_niveau.SelectedValue);
        cmd.Parameters.AddWithValue("@holdFoto", "Standard.jpg");



        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("Oprethold.aspx");
    }
}