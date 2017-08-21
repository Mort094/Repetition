using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM stilart", conn);


            conn.Open();
            showAllStilArt.DataSource = cmd.ExecuteReader();
            showAllStilArt.DataBind();
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
                                                        On hold.FK_stilartId = stilart.stilartId", conn);


            conn.Open();
            showAllTeams.DataSource = cmd.ExecuteReader();
            showAllTeams.DataBind();
            conn.Close();
        }
    }



    protected void showAllTeams_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (showAllTeams.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl_fail = (Label)e.Item.FindControl("lbl_fail");
                lbl_fail.Visible = true;
            }
        }
    }
}