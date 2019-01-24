using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CrudInGridView
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\d\CrudInGridView\CrudInGridView\App_Data\UchetBD.mdf;Integrated Security=True";
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UchetT", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvUchet.DataSource = dtbl;
                gvUchet.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvUchet.DataSource = dtbl;
                gvUchet.DataBind();
                gvUchet.Rows[0].Cells.Clear();
                gvUchet.Rows[0].Cells.Add(new TableCell());
                gvUchet.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvUchet.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvUchet.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvUchet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO UchetT (Sotrudnik,DataPost,NazvaniePredmeta,Kolichestvo,DataVida,Adress,FIOPoluch,Cena) VALUES (@Sotrudnik,@DataPost,@NazvaniePredmeta,@Kolichestvo,@DataVida,@Adress,@FIOPoluch,@Cena)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Sotrudnik", (gvUchet.FooterRow.FindControl("txtSotrudnikFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DataPost", (gvUchet.FooterRow.FindControl("txtDataPostFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@NazvaniePredmeta", (gvUchet.FooterRow.FindControl("txtNazvaniePredmetaFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Kolichestvo", (gvUchet.FooterRow.FindControl("txtKolichestvoFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DataVida", (gvUchet.FooterRow.FindControl("txtDataVidaFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Adress", (gvUchet.FooterRow.FindControl("txtAdressFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@FIOPoluch", (gvUchet.FooterRow.FindControl("txtFIOPoluchFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Cena", (gvUchet.FooterRow.FindControl("txtCenaFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvUchet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUchet.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvUchet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUchet.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvUchet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE UchetT SET Sotrudnik=@Sotrudnik,DataPost=@DataPost,NazvaniePredmeta=@NazvaniePredmeta,Kolichestvo=@Kolichestvo,DataVida=@DataVida,Adress=@Adress,FIOPoluch=@FIOPoluch,Cena=@Cena WHERE MainID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Sotrudnik", (gvUchet.Rows[e.RowIndex].FindControl("txtSotrudnik") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DataPost", (gvUchet.Rows[e.RowIndex].FindControl("txtDataPost") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@NazvaniePredmeta", (gvUchet.Rows[e.RowIndex].FindControl("txtNazvaniePredmeta") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Kolichestvo", (gvUchet.Rows[e.RowIndex].FindControl("txtKolichestvo") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@DataVida", (gvUchet.Rows[e.RowIndex].FindControl("txtDataVida") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Adress", (gvUchet.Rows[e.RowIndex].FindControl("txtAdress") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@FIOPoluch", (gvUchet.Rows[e.RowIndex].FindControl("txtFIOPoluch") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cena", (gvUchet.Rows[e.RowIndex].FindControl("txtCena") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id",Convert.ToInt32(gvUchet.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvUchet.EditIndex = -1;
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

        protected void gvUchet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM UchetT WHERE MainID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvUchet.DataKeys[e.RowIndex].Value.ToString()));
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