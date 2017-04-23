using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;
using System.IO;

namespace WebAppTUR.Servicios
{
    
    public partial class ServicioPrecio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["User"] != "")
                {
                    BindData();
                    MultiView1.SetActiveView(View2);
                }
                   //AddControls(3);ç

                else { Response.Redirect("~/index.aspx"); }

            }
        }
        private void BindData()
        {
            List<ModelClasses.ServicioPrecio> ds = new List<ModelClasses.ServicioPrecio>();
            ds = ServicioPrecioDAL.getAllServicioPrecio();
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

        private void LoadDDLCiudad()
        {
            //StringBuilder sb = new StringBuilder();
            List<Ciudad> ciudades = new List<Ciudad>();
            ciudades = CiudadesDAL.getAllCiudades();
            ddlCiudad.Items.Clear();
            // <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
            ddlCiudad.Items.Add("--Seleccione una Ciudad--");
            ddlCiudad.DataSource = ciudades;
            ddlCiudad.DataValueField = "Id";
            ddlCiudad.DataTextField = "CodigoInterno";
            ddlCiudad.DataBind();


        }
        private void LoadMoneda()
        {
            List<ModelClasses.Divisa> divisas = new List<ModelClasses.Divisa>();
            divisas = DivisasDAL.getAllDivisas();
            ddlMoneda.Items.Clear();
            ddlMoneda.Items.Add("--Seleccione una Moneda--");
            ddlMoneda.DataSource = divisas;
            ddlMoneda.DataValueField = "Id";
            ddlMoneda.DataTextField = "Nombre";
            ddlMoneda.DataBind();


        }
        protected void New_Click(object sender, EventArgs e)
        {
            //clean
            cleanFields();
            MultiView1.SetActiveView(View1);
            BTNSaveUpdat.Visible = false;
            TXTPrecioEdit.Visible = false;
            LabelOperador.Visible = false;
            labelCiudad.Visible = false;
            txtSVS.Visible = false;
            lblsvs.Visible = false;
            lblPrecio.Visible = false;
            NombreEditando.Visible = false;
            lblNombreEdit.Visible = false;
        }

        private void cleanFields()
        {
            //throw new NotImplementedException();
            LoadDDLCiudad();
            LoadMoneda();
            GridPreciosLista.DataSource = null;
            GridPreciosLista.DataBind();
            TXTError.Text = "";
            Fdesde.Text= "";
            Fhasta.Text = "";
            ddlOperador.Items.Clear();
        }
        protected void Ciudad_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlCiudad.SelectedValue != "--Seleccione una Ciudad--")
            {
                ddlOperador.Items.Clear();
                List<ModelClasses.Operador> Operador = new List<ModelClasses.Operador>();
                Operador = OperadorDAL.GetOperadorporCiudad(Convert.ToInt32(ddlCiudad.SelectedValue));
                ddlOperador.DataSource = Operador;
                ddlOperador.Items.Add("--Seleccione un operador--");
                ddlOperador.DataValueField = "Id";
                ddlOperador.DataTextField = "Nombre";
                ddlOperador.DataBind();
            }
            else { ddlOperador.Items.Clear(); }

        }

        protected void Operador_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            List<ModelClasses.Servicio> listServicios = new List<ModelClasses.Servicio>();
            int idselected = Convert.ToInt32(Convert.ToInt32(ddlOperador.SelectedValue));
            listServicios= ServicioDAL.GetServicioporOperador(idselected);
            int cantidadServicios = listServicios.Count();
            AddControls(listServicios);

        }
        protected void SaveNew_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Fdesde.Text) && !String.IsNullOrEmpty(Fhasta.Text) && ddlMoneda.SelectedValue != "--Seleccione una Moneda--")
            {
                DateTime FDesde = Convert.ToDateTime(Fdesde.Text);
                DateTime FHasta = Convert.ToDateTime(Fhasta.Text);
                if (FDesde < FHasta)
                {
                    TXTError.Text = "";
                    List<ModelClasses.ServicioPrecio> list = obtenerPrecios();
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            ServicioPrecioDAL.newServicioPrecio(item);
                        }
                        BindData();
                        MultiView1.SetActiveView(View2);
                        cleanFields();
                    }
                }
                else
                {
                    TXTError.Text = " *Seleccione una fecha desde mayor que la fecha hasta.";
                    TXTError.ForeColor = System.Drawing.Color.Red;

                }
            }
            else
            {
                TXTError.Text = "Los campos moneda y las fechas son obligatorios.";
                TXTError.ForeColor = System.Drawing.Color.Red;
            }
           
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            BindData();
            MultiView1.SetActiveView(View2);
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            MultiView1.SetActiveView(View1);
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Session["ID"] = id;
            LoadDataToEdit(id);            
        }

        private void LoadDataToEdit(int Id)
        {
            LoadDDLCiudad();
            LoadMoneda();
            lblsvs.Visible = true;
            ModelClasses.ServicioPrecio ServPrecioEdit = new ModelClasses.ServicioPrecio();
            ServPrecioEdit = DAL.ServicioPrecioDAL.GetoneServicioPrecio(Id);
            txtSVS.Text = ServPrecioEdit.TipoServicio;
            txtSVS.Visible = true;
            TXTPrecioEdit.Visible = true;
            BTNSaveUpdat.Visible = true;            
            TXTPrecioEdit.Text = ServPrecioEdit.Precio.ToString();
            BTNSavenew.Visible = false;
            ddlCiudad.Visible = false;
            ddlOperador.Visible = false;
            LabelOperador.Visible = true;
            labelCiudad.Visible = true;
            NombreEditando.Visible = true;
            lblNombreEdit.Visible = true;
            NombreEditando.Text = ServPrecioEdit.NombreServicio;
            labelCiudad.Text = ServPrecioEdit.CiudadServicio;
            LabelOperador.Text = ServPrecioEdit.OperadorServicio;
            ddlMoneda.SelectedValue = ServPrecioEdit.Moneda;
            Fdesde.Text = ServPrecioEdit.FechaDesde.ToString("M/d/yyyy");
            Fhasta.Text = ServPrecioEdit.FechaHasta.ToString("M/d/yyyy");
            

        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar" + "');", true);
            ServicioPrecio deleteprecio = new ServicioPrecio();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            DAL.ServicioPrecioDAL.DeleteServicio(id);
            BindData();
            MultiView1.SetActiveView(View2);

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        private void AddControls(List<ModelClasses.Servicio> cantRowToAdd)
        {
            GridPreciosLista.DataSource = cantRowToAdd;
            GridPreciosLista.DataBind();
        }
        private List<ModelClasses.ServicioPrecio> obtenerPrecios()
        {
           
            TextBox txttipo1 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo1");
            TextBox txttipo2 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo2");
            TextBox txttipo3 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo3");
            TextBox txttipo4 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo4");
            TextBox txttipo5 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo5");
            TextBox txttipo6 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo6");
            TextBox txttipo7 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo7");
            TextBox txttipo8 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo8");
            TextBox txttipo9 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo9");
            TextBox txttipo10 = (TextBox)GridPreciosLista.HeaderRow.FindControl("txtTipo10");
            
            List<ModelClasses.ServicioPrecio> listPrecioServicios = new List<ModelClasses.ServicioPrecio>();
            DateTime FechaDesde = Convert.ToDateTime(Fdesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(Fhasta.Text); 
            
            var rows = GridPreciosLista.Rows;
            
            foreach (GridViewRow row in rows)
            {
                int id = (int)GridPreciosLista.DataKeys[row.RowIndex].Value;

                TextBox txtP1 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio1");
                Button txtB1 = (Button)row.Cells[0].FindControl("btn1");
               
                if (txtP1.Text != "" & txttipo1.Text != "") 
                {
                    ModelClasses.ServicioPrecio servicioP1 = new ModelClasses.ServicioPrecio();
                    servicioP1.IdOperador =Convert.ToInt32(Convert.ToInt32(ddlOperador.SelectedValue));
                    servicioP1.IdServicio= id;
                    servicioP1.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP1.Precio = Convert.ToDecimal(txtP1.Text);
                    servicioP1.TipoServicio = txttipo1.Text;
                    servicioP1.FechaDesde = FechaDesde;
                    servicioP1.FechaHasta = FechaHasta;
                    servicioP1.UnitarioGrupal = txtB1.Text;
                    listPrecioServicios.Add(servicioP1);
                }

                TextBox txtP2 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio2");
                Button txtB2 = (Button)row.Cells[0].FindControl("btn2");
                if (txtP2.Text != "" & txttipo2.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP2 = new ModelClasses.ServicioPrecio();
                    servicioP2.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP2.IdServicio = id;
                    servicioP2.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP2.Precio = Convert.ToDecimal(txtP2.Text);
                    servicioP2.TipoServicio = txttipo2.Text;
                    servicioP2.FechaDesde = FechaDesde;
                    servicioP2.FechaHasta = FechaHasta;
                    servicioP2.UnitarioGrupal = txtB2.Text;
                    listPrecioServicios.Add(servicioP2);
                }
                TextBox txtP3 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio3");
                Button txtB3 = (Button)row.Cells[0].FindControl("btn3");
                if (txtP3.Text != "" & txttipo3.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP3 = new ModelClasses.ServicioPrecio();
                    servicioP3.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP3.IdServicio = id;
                    servicioP3.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP3.Precio = Convert.ToDecimal(txtP3.Text);
                    servicioP3.TipoServicio = txttipo3.Text;
                    servicioP3.FechaDesde = FechaDesde;
                    servicioP3.FechaHasta = FechaHasta;
                    servicioP3.UnitarioGrupal = txtB3.Text;
                    listPrecioServicios.Add(servicioP3);
                }
                TextBox txtP4 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio4");
                Button txtB4 = (Button)row.Cells[0].FindControl("btn4");
                if (txtP4.Text != "" & txttipo4.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP4 = new ModelClasses.ServicioPrecio();
                    servicioP4.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP4.IdServicio = id;
                    servicioP4.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP4.Precio = Convert.ToDecimal(txtP4.Text);
                    servicioP4.TipoServicio = txttipo4.Text;
                    servicioP4.FechaDesde = FechaDesde;
                    servicioP4.FechaHasta = FechaHasta;
                    servicioP4.UnitarioGrupal = txtB4.Text;
                    listPrecioServicios.Add(servicioP4);
                }
                TextBox txtP5 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio5");
                Button txtB5 = (Button)row.Cells[0].FindControl("btn5");
                if (txtP5.Text != "" & txttipo5.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP5 = new ModelClasses.ServicioPrecio();
                    servicioP5.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP5.IdServicio = id;
                    servicioP5.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP5.Precio = Convert.ToDecimal(txtP5.Text);
                    servicioP5.TipoServicio = txttipo5.Text;
                    servicioP5.FechaDesde = FechaDesde;
                    servicioP5.FechaHasta = FechaHasta;
                    servicioP5.UnitarioGrupal = txtB5.Text;
                    listPrecioServicios.Add(servicioP5);
                }
                TextBox txtP6 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio6");
                Button txtB6 = (Button)row.Cells[0].FindControl("btn6");
                if (txtP6.Text != "" & txttipo6.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP6 = new ModelClasses.ServicioPrecio();
                    servicioP6.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP6.IdServicio = id;
                    servicioP6.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP6.Precio = Convert.ToDecimal(txtP6.Text);
                    servicioP6.TipoServicio = txttipo6.Text;
                    servicioP6.FechaDesde = FechaDesde;
                    servicioP6.FechaHasta = FechaHasta;
                    servicioP6.UnitarioGrupal = txtB6.Text;
                    listPrecioServicios.Add(servicioP6);
                }
                TextBox txtP7 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio7");
                Button txtB7 = (Button)row.Cells[0].FindControl("btn7");
                if (txtP7.Text != "" & txttipo7.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP7 = new ModelClasses.ServicioPrecio();
                    servicioP7.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP7.IdServicio = id;
                    servicioP7.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP7.Precio = Convert.ToDecimal(txtP7.Text);
                    servicioP7.TipoServicio = txttipo7.Text;
                    servicioP7.FechaDesde = FechaDesde;
                    servicioP7.FechaHasta = FechaHasta;
                    servicioP7.UnitarioGrupal = txtB7.Text;
                    listPrecioServicios.Add(servicioP7);
                }
                TextBox txtP8 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio8");
                Button txtB8 = (Button)row.Cells[0].FindControl("btn8");
                if (txtP8.Text != "" & txttipo8.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP8 = new ModelClasses.ServicioPrecio();
                    servicioP8.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP8.IdServicio = id;
                    servicioP8.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP8.Precio = Convert.ToDecimal(txtP8.Text);
                    servicioP8.TipoServicio = txttipo8.Text;
                    servicioP8.FechaDesde = FechaDesde;
                    servicioP8.FechaHasta = FechaHasta;
                    servicioP8.UnitarioGrupal = txtB8.Text;
                    listPrecioServicios.Add(servicioP8);
                }
                TextBox txtP9 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio9");
                Button txtB9 = (Button)row.Cells[0].FindControl("btn9");
                if (txtP9.Text != "" & txttipo9.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP9 = new ModelClasses.ServicioPrecio();
                    servicioP9.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP9.IdServicio = id;
                    servicioP9.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP9.Precio = Convert.ToDecimal(txtP9.Text);
                    servicioP9.TipoServicio = txttipo9.Text;
                    servicioP9.FechaDesde = FechaDesde;
                    servicioP9.FechaHasta = FechaHasta;
                    servicioP9.UnitarioGrupal = txtB9.Text;
                    listPrecioServicios.Add(servicioP9);
                }
                TextBox txtP10 = (TextBox)row.Cells[0].FindControl("txtTipoPrecio10");
                Button txtB10 = (Button)row.Cells[0].FindControl("btn10");
                if (txtP10.Text != "" & txttipo10.Text != "")
                {
                    ModelClasses.ServicioPrecio servicioP10 = new ModelClasses.ServicioPrecio();
                    servicioP10.IdOperador = Convert.ToInt32(ddlOperador.SelectedValue);
                    servicioP10.IdServicio = id;
                    servicioP10.Moneda = ddlMoneda.SelectedValue.ToString();
                    servicioP10.Precio = Convert.ToDecimal(txtP10.Text);
                    servicioP10.TipoServicio = txttipo10.Text;
                    servicioP10.FechaDesde = FechaDesde;
                    servicioP10.FechaHasta = FechaHasta;
                    servicioP10.UnitarioGrupal = txtB10.Text;
                    listPrecioServicios.Add(servicioP10);
                }
               
            
            }

            return listPrecioServicios;
            
            
        }
   
        protected void Grupal(object sender, EventArgs e) {
        
        }
        protected void UnitGroup_Click(object sender, EventArgs e)
        { 
             Button value =(Button) sender;
             if (value.Text == "Unit") { value.Text = "Grup"; } else { value.Text = "Unit"; }
        }
        protected void SaveUpdat_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ID"]);
            ModelClasses.ServicioPrecio precio1 = new ModelClasses.ServicioPrecio();
            precio1.Id = id;
            DateTime FechaDesde = Convert.ToDateTime(Fdesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(Fhasta.Text);
            precio1.FechaDesde = FechaDesde;
            precio1.FechaHasta = FechaHasta;
            precio1.Precio =  Convert.ToDecimal(TXTPrecioEdit.Text);
            precio1.TipoServicio = txtSVS.Text;
            precio1.Moneda = ddlMoneda.SelectedValue.ToString();
            ServicioPrecioDAL.EditServicioPrecio(precio1);
            Session["ID"] = "";
            BindData();
            MultiView1.SetActiveView(View2);
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            BindData();
        }
        protected void GridPreciosLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;
            BindData();
            var DataSource = (IList<ModelClasses.ServicioPrecio>)Grid.DataSource;
            switch (sortExpression)
            {
                case "CiudadServicio":
                    DataSource = (from c in DataSource
                                  orderby c.CiudadServicio ascending
                                  select c).ToList();
                    break;
                case "OperadorServicio":
                    DataSource = (from c in DataSource
                                  orderby c.OperadorServicio ascending
                                  select c).ToList();
                    break;
                case "ActividadServicio":
                    DataSource = (from c in DataSource
                                  orderby c.ActividadServicio ascending
                                  select c).ToList();
                    break;
                case "NombreServicio":
                    DataSource = (from c in DataSource
                                  orderby c.NombreServicio ascending
                                  select c).ToList();
                    break;
                case "TipoServicio":
                    DataSource = (from c in DataSource
                                  orderby c.TipoServicio ascending
                                  select c).ToList();
                    break;
                case "FdesdeServicio":
                    DataSource = (from c in DataSource
                                  orderby c.FdesdeServicio ascending
                                  select c).ToList();
                    break;
                case "FHastaServicio":
                    DataSource = (from c in DataSource
                                  orderby c.FHastaServicio ascending
                                  select c).ToList();
                    break;
            }
            Grid.DataSource = DataSource;
            Grid.DataBind();

        }


    }
}