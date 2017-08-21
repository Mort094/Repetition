using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stilart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM stilart WHERE stilartId = @s_id", conn);
            cmd.Parameters.AddWithValue("@s_id", Request.QueryString["stilartId"]);

            conn.Open();
            repeater_showStilArt.DataSource = cmd.ExecuteReader();
            repeater_showStilArt.DataBind();
            conn.Close();
        }
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT *, alderNavn, instruktorNavn, niveauNavn, stilartNavn
                                                        FROM hold
                                                    INNER JOIN alder
                                                        On hold.FK_alderId = alder.alderId
                                                    INNER JOIN instruktor
                                                        On hold.FK_instruktorId = instruktor.instruktorId
                                                    INNER JOIN niveau
                                                        On hold.FK_niveauId = niveau.niveauId
                                                    INNER JOIN stilart
                                                        On hold.FK_stilartId = stilart.stilartId
                                                    WHERE stilart.stilartId = @s_id ", conn);
            cmd.Parameters.AddWithValue("@s_id", Request.QueryString["stilartId"]);

            conn.Open();
            repeater_showTeams.DataSource = cmd.ExecuteReader();
            repeater_showTeams.DataBind();
            conn.Close();
        }
    }

    protected void repeater_showTeams_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (repeater_showTeams.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl_fail = (Label)e.Item.FindControl("lbl_fail");
                lbl_fail.Visible = true;
            }
        }
    }

    protected void repeater_showTeams_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //Er du logget ind? 
        if (Session["brugerId"] != null)
        {
            if (e.CommandName == "tilmeld")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;


                cmd.CommandText = @"SELECT * FROM tilmeld WHERE fk_brugerId = @brugerId and fk_holdId = @holdId";
                cmd.Parameters.AddWithValue("@holdId", e.CommandArgument);
                cmd.Parameters.AddWithValue("@brugerId", Session["brugerId"]);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    lbl_info.Visible = true;
                    lbl_info.Text = "Du er tilmeldt dette hold";

                }
                else
                {
                    reader.Close();
                    //Hvis ja, tilmeld

                    cmd.Connection = conn;

                    cmd.CommandText = @"INSERT INTO tilmeld (fk_holdId, fk_brugerID) 
                                        VALUES (@holdID, @brugerId)";

                    //cmd.Parameters.AddWithValue("@holdId", e.CommandArgument);
                    //cmd.Parameters.AddWithValue("@brugerId", Session["brugerId"]);


                   
                    cmd.ExecuteNonQuery();
                   
                    Response.Redirect("Brugerside.aspx");
                }
                conn.Close();






            }
        }

        else
        {
            //Hvis nej, redirect
            Response.Redirect("Login.aspx");
        }



    }
}