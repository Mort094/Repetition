using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Holdoversigt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT brugere.brugerNavn, hold.holdNavn
                                                    FROM tilmeld
                                                    INNER JOIN hold
                                                        ON tilmeld.fk_holdId = hold.holdId
                                                    INNER JOIN brugere
                                                        ON tilmeld.fk_brugerId = brugere.brugerId
                                                    WHERE hold.holdId = @holdId", conn);
            cmd.Parameters.AddWithValue("@holdId", Request.QueryString["Holdid"]);


            conn.Open();
            repeater_data.DataSource = cmd.ExecuteReader();
            repeater_data.DataBind();
            conn.Close();
        }
    }
}