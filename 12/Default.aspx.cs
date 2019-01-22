using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace _12
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ALLO\source\repos\12\12\App_Data\Sklad.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridview();
            }
        }
        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Info", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                Uchet.DataSource = dtbl;
                Uchet.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                Uchet.DataSource = dtbl;
                Uchet.DataBind();
                Uchet.Rows[0].Cells.Clear();
                Uchet.Rows[0].Cells.Add(new TableCell());
                Uchet.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                Uchet.Rows[0].Cells[0].Text = "No Data Found";
                Uchet.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void Uchet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("AddNew"))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Info (Sotrudnik,DataPost,NazvaniePredmeta,Kolichestvo,DataVida,Adress,FIOPoluch,Cena) VALUES (@Sotrudnik,@DataPost,@NazvaniePredmeta,@Kolichestvo,@DataVida,@Adress,@FIOPoluch,@Cena)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Sotrudnik",(Uchet.FooterRow.FindControl("txtSotrudnikFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DataPost", (Uchet.FooterRow.FindControl("txtDataPostFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@NazvaniePredmeta", (Uchet.FooterRow.FindControl("txtNazvaniePredmetaFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Kolichestvo", (Uchet.FooterRow.FindControl("txtKolichestvoFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DataVida", (Uchet.FooterRow.FindControl("txtDataVidaFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Adress", (Uchet.FooterRow.FindControl("txtAdressFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FIOPoluch", (Uchet.FooterRow.FindControl("txtFIOPoluchFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cena", (Uchet.FooterRow.FindControl("txtCenaFooter") as TextBox).Text.Trim());

                }
            }
        }
    }
}