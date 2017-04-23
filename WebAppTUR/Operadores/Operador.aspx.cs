using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;


namespace WebAppTUR.Operadores
{
    public partial class Operador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        private void BindData()
        {
            List<ModelClasses.Operador> ds = new List<ModelClasses.Operador>();
            ds = OperadorDAL.getAllOperador();
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
            LoadDDLCiudad();
        }
       

        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            BTNSavenew.Visible = false;
            BTNSaveUpdat.Visible = true;
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Session["ID"] = id;
            ModelClasses.Operador operadortoedit = new ModelClasses.Operador();
            operadortoedit =  OperadorDAL.GetoneOperador(id);
            MultiView1.SetActiveView(View1);
            TXTnombre.Text = operadortoedit.Nombre;
            TXTEmail.Text = operadortoedit.Email;
            TXTBcoNombre.Text = operadortoedit.NombreBco;
            TXTCBU.Text = operadortoedit.CBU;
            TXTCodPost.Text = operadortoedit.CodPostal;
            TXTContacto.Text = operadortoedit.Contacto;
            TXTCta.Text = operadortoedit.NumeroCuenta;
            TXTCuit.Text = operadortoedit.Cuit;
            TXTTelefono.Text = operadortoedit.Telefono;
            TXTFax.Text = operadortoedit.Fax;
            TXTDireccionBco.Text = operadortoedit.DireccionBco;
            TXTDireccion.Text = operadortoedit.Direcion;
            
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar" + "');", true);
            DAL.Operador deleteOperador = new DAL.Operador();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            deleteOperador.Id = id;
            OperadorDAL.DeleteOperador(deleteOperador);
            BindData();

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }
        
        private void LoadDDLCiudad()
        {
            //StringBuilder sb = new StringBuilder();
            List<Ciudad> ciudades = new List<Ciudad>();
            ciudades = CiudadesDAL.getAllCiudades();
            ddlCiudad.DataSource = ciudades;
            ddlCiudad.DataValueField = "Id";
            ddlCiudad.DataTextField = "CodigoInterno";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, "<-- Seleccione -->");

        }
        private void CleanField()
        {
            TXTnombre.Text = string.Empty;
            TXTEmail.Text = string.Empty;
            TXTBcoNombre.Text = string.Empty;
            TXTCBU.Text = string.Empty;
            TXTCodPost.Text = string.Empty;
            TXTContacto.Text = string.Empty;
            TXTCta.Text = string.Empty;
            TXTCuit.Text = string.Empty;
            TXTTelefono.Text = string.Empty;
            TXTTelefono.Text = string.Empty;
            TXTFax.Text = string.Empty;
            TXTDireccionBco.Text = string.Empty;
            TXTDireccion.Text = string.Empty;
            LoadDDLCiudad();

        }

        protected void SaveUpdat_Click(object sender, EventArgs e)
        {
            if (TXTDireccion.Text != "" && TXTnombre.Text != "" && TXTTelefono.Text != "" && Session["ID"] != "")
            {
                ModelClasses.Operador nuevoOp = new ModelClasses.Operador();
                nuevoOp.Id = Convert.ToInt32( Session["ID"]);
                nuevoOp.Nombre = TXTnombre.Text.Trim();
                //nuevoOp. = TXTWeb.Text.Trim();
                nuevoOp.Fax = TXTFax.Text.Trim();
                nuevoOp.Email = TXTEmail.Text.Trim();
                nuevoOp.NombreBco = TXTBcoNombre.Text.Trim();
                nuevoOp.CBU = TXTCBU.Text.Trim();
                nuevoOp.CodPostal = TXTCodPost.Text.Trim();
                nuevoOp.Contacto = TXTContacto.Text.Trim();
                nuevoOp.NumeroCuenta = TXTCta.Text.Trim();
                nuevoOp.Cuit = TXTCuit.Text.Trim();
                nuevoOp.Telefono = TXTTelefono.Text.Trim();
                //nuevoOp.Nombre = TXTTwitter.Text.Trim();
                nuevoOp.Fax = TXTFax.Text.Trim();
                nuevoOp.DireccionBco = TXTDireccionBco.Text.Trim();
                nuevoOp.Direcion = TXTDireccion.Text.Trim();
                int IDCiudad = Convert.ToInt16(ddlCiudad.SelectedValue);
                nuevoOp.Ciudad = CiudadesDAL.GetOneById(IDCiudad);
                //nuevoOp.ob = TXTObsBanco.Text.Trim();
                OperadorDAL.EditOperador(nuevoOp);
                BindData();
                Session["ID"] = "";

            }

            MultiView1.SetActiveView(View2);
        }       
        protected void SaveNew_Click(object sender, EventArgs e)
        {
            if (TXTDireccion.Text != "" && TXTnombre.Text != "" && TXTTelefono.Text != "")
            {
                ModelClasses.Operador nuevoOp = new ModelClasses.Operador();
                nuevoOp.Nombre = TXTnombre.Text.Trim();
                nuevoOp.Email = TXTEmail.Text.Trim();
                nuevoOp.NombreBco = TXTBcoNombre.Text.Trim();
                nuevoOp.CBU = TXTCBU.Text.Trim();
                nuevoOp.CodPostal = TXTCodPost.Text.Trim();
                nuevoOp.Contacto = TXTContacto.Text.Trim();
                nuevoOp.NumeroCuenta = TXTCta.Text.Trim();
                nuevoOp.Cuit = TXTCuit.Text.Trim();
                nuevoOp.Telefono = TXTTelefono.Text.Trim();
                nuevoOp.Fax = TXTFax.Text.Trim();
                nuevoOp.DireccionBco = TXTDireccionBco.Text.Trim();
                nuevoOp.Direcion = TXTDireccion.Text.Trim();
                int IDCiudad = Convert.ToInt16(ddlCiudad.SelectedValue);
                nuevoOp.Ciudad = CiudadesDAL.GetOneById(IDCiudad);
                OperadorDAL.newOperador(nuevoOp);
                BindData();


            }

            MultiView1.SetActiveView(View2);

        }
        protected void New_Click(object sender, EventArgs e)
        {
            BTNSaveUpdat.Visible = false;
            BTNSavenew.Visible = true;
            MultiView1.Visible = true;
            CleanField();
            MultiView1.SetActiveView(View1);
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            CleanField();
            MultiView1.SetActiveView(View2);

        }

        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;
            BindData();
            var DataSource = (IList<ModelClasses.Operador>)Grid.DataSource;
            switch (sortExpression)
            {
                case "Nombre":
                    DataSource = (from c in DataSource
                                  orderby c.Nombre ascending
                                  select c).ToList();
                    break;
                case "CiudadNombre":
                    DataSource = (from c in DataSource
                                  orderby c.CiudadNombre ascending
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