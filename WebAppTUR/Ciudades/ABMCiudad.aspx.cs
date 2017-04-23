using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;

namespace WebAppTUR.Ciudades
{
    public partial class ABMCiudad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (!IsPostBack)
                {
                    if (Session["User"] != null && Session["User"] != "")
                    {

                        MultiView1.SetActiveView(View2);
                        BindData();
                    }
                    else { Response.Redirect("~/index.aspx"); }

                }
            }
            catch (Exception ex)
            {
             //else { Response.Redirect("~/index.aspx"); }
            }
            

        }

        private void BindData()
        {
            List<Ciudad> ds = new List<Ciudad>();
            ds = CiudadesDAL.getAllCiudades();
            if (ds.Count > 0)
            {
                Grid.DataSource = ds;
                Grid.DataBind();
            }
            else
            {
                Grid.DataSource = null;
                Grid.DataBind();
            }

        }
        protected void SaveNew_Click(object sender, EventArgs e)
        {
            if (TXTCodigo.Text != "" && TXTnombre.Text != "" && TXTPais.Text != "")
            {
                ModelClasses.Ciudad nuevaCiudad = new ModelClasses.Ciudad();
                nuevaCiudad.Nombre = TXTnombre.Text.Trim();
                nuevaCiudad.Codigo = TXTCodigo.Text.Trim();
                nuevaCiudad.Pais = TXTPais.Text.Trim();
                CiudadesDAL.newciudad(nuevaCiudad);
                BindData();


            }

            MultiView1.SetActiveView(View2);

        }
        protected void New_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            TXTnombre.Text = string.Empty;
            TXTCodigo.Text = string.Empty;
            TXTPais.Text = string.Empty;
            MultiView1.SetActiveView(View1);
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);

        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = e.Item.ItemIndex;
            BindData();

        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar" + "');", true);
            Ciudad updateCiudad = new Ciudad();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            updateCiudad.Id = id;
            CiudadesDAL.DeleteCiudad(updateCiudad);
            BindData();
            MultiView1.SetActiveView(View2);
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

            DAL.Ciudades updateCiudad = new DAL.Ciudades();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            updateCiudad.Id = id;
            updateCiudad.Nombre = ((TextBox)e.Item.Cells[0].Controls[0]).Text.Trim();
            updateCiudad.Pais = ((TextBox)e.Item.Cells[1].Controls[0]).Text.Trim();
            updateCiudad.Codigo = ((TextBox)e.Item.Cells[2].Controls[0]).Text.Trim();
            CiudadesDAL.EditCiudad(updateCiudad);
            Grid.EditItemIndex = -1;
            BindData();
            MultiView1.SetActiveView(View2);

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;
            BindData();
            var DataSource = (IList<Ciudad>) Grid.DataSource;
            switch (sortExpression)
            {
                case "Nombre":
                    DataSource = (from c in DataSource
                                  orderby c.Nombre ascending
                                  select c).ToList();
                    break;
                case "Codigo":
                    DataSource = (from c in DataSource
                                 orderby c.Codigo ascending
                                 select c).ToList();
                    break;
                case "Pais":
                    DataSource = (from c in DataSource
                                  orderby c.Pais ascending
                                  select c).ToList();
                    break;
            }
            Grid.DataSource = DataSource;
            Grid.DataBind();
            
        }

       
    }
}