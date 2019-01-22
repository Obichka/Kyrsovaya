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
            if (!IsPostBack)
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
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Info (Sotrudnik,DataPost,NazvaniePredmeta,Kolichestvo,DataVida,Adress,FIOPoluch,Cena) VALUES (@Sotrudnik,@DataPost,@NazvaniePredmeta,@Kolichestvo,@DataVida,@Adress,@FIOPoluch,@Cena)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Sotrudnik", (Uchet.FooterRow.FindControl("txtSotrudnikFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DataPost", (Uchet.FooterRow.FindControl("txtDataPostFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@NazvaniePredmeta", (Uchet.FooterRow.FindControl("txtNazvaniePredmetaFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Kolichestvo", (Uchet.FooterRow.FindControl("txtKolichestvoFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DataVida", (Uchet.FooterRow.FindControl("txtDataVidaFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Adress", (Uchet.FooterRow.FindControl("txtAdressFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@FIOPoluch", (Uchet.FooterRow.FindControl("txtFIOPoluchFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Cena", (Uchet.FooterRow.FindControl("txtCenaFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New record added";
                        lblErrorMessage.Text = "";


                    }
                }
            }
            catch (Exception ex)
            {

                lblSuccessMessage.Text = "New record added";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void Uchet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Uchet.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void Uchet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Uchet.EditIndex = -1;
            PopulateGridview();
        }

        protected void Uchet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Info SET Sotrudnik=@Sotrudnik,DataPost=@DataPost,NazvaniePredmeta=@NazvaniePredmeta,Kolichestvo=@Kolichestvo,DataVida=@DataVida,Adress=@Adress,FIOPoluch=@FIOPoluch,Cena=@Cena WHERE infoId = @infoid";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Sotrudnik", (Uchet.Rows[e.RowIndex].FindControl("txtSotrudnik") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DataPost", (Uchet.Rows[e.RowIndex].FindControl("txtDataPost") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@NazvaniePredmeta", (Uchet.Rows[e.RowIndex].FindControl("txtNazvaniePredmeta") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Kolichestvo", (Uchet.Rows[e.RowIndex].FindControl("txtKolichestvo") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DataVida", (Uchet.Rows[e.RowIndex].FindControl("txtDataVida") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Adress", (Uchet.Rows[e.RowIndex].FindControl("txtAdress") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FIOPoluch", (Uchet.Rows[e.RowIndex].FindControl("txtFIOPoluch") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cena", (Uchet.Rows[e.RowIndex].FindControl("txtCena") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@infoid", Convert.ToInt32(Uchet.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    Uchet.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";


                }

            }
            catch (Exception ex)
            {

                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void Uchet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Info WHERE infoid = @infoid";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@infoid", Convert.ToInt32(Uchet.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();

                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";


                }
            }

            catch (Exception ex)
            {

                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}