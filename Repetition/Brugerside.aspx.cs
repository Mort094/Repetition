using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Brugerside : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["brugerId"] != null)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand cmd = new SqlCommand(@"SELECT * FROM brugere WHERE brugerId = @brugerId", conn);

                cmd.Parameters.AddWithValue("@brugerId", Session["brugerId"]);
                conn.Open();
                repeater_brugerInfo.DataSource = cmd.ExecuteReader();
                repeater_brugerInfo.DataBind();
                conn.Close();
            }
        }
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT *, alderNavn, instruktorNavn, niveauNavn, stilartNavn, brugerId
                                                        FROM hold
                                                    INNER JOIN alder
                                                        On hold.FK_alderId = alder.alderId
                                                    INNER JOIN instruktor
                                                        On hold.FK_instruktorId = instruktor.instruktorId
                                                    INNER JOIN niveau
                                                        On hold.FK_niveauId = niveau.niveauId
                                                    INNER JOIN stilart
                                                        On hold.FK_stilartId = stilart.stilartId
                                                    INNER JOIN tilmeld
                                                        On tilmeld.fk_holdId = hold.holdId
                                                    INNER JOIN brugere
                                                        On tilmeld.fk_brugerID = brugere.brugerId
                                                    WHERE brugerId = @brugerId", conn);
            cmd.Parameters.AddWithValue("@brugerId", Session["brugerId"]);

            conn.Open();
            repeater_holdInfo.DataSource = cmd.ExecuteReader();
            repeater_holdInfo.DataBind();
            conn.Close();
        }
    }





    protected void repeater_holdInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (repeater_holdInfo.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl_fail = (Label)e.Item.FindControl("lbl_fail");
                lbl_fail.Visible = true;
            }
        }
    }

    protected void repeater_holdInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //Er du logget ind? 
        if (Session["brugerId"] != null)
        {
            if (e.CommandName == "frameld")
            {


                //Hvis ja, tilmeld
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM tilmeld WHERE fk_holdId = @fk_holdId";
                cmd.Parameters.AddWithValue("@fk_holdId", e.CommandArgument);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
               
                Response.Redirect("Brugerside.aspx");

            }
        }

        else
        {
            //Hvis nej, redirect
            Response.Redirect("Login.aspx");
        }
    }
}