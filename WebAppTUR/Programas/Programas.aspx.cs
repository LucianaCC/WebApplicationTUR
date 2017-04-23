using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTUR.Programas
{
    public partial class Programas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["User"] != null && Session["User"] != "")
                    {

                        MultiView1.SetActiveView(View2);
                       // BindData();// get all programms

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
            //llenar grilla aereos
            List<ModelClasses.Servicio> listAereos2 = new List<ModelClasses.Servicio>();
            List<ModelClasses.Servicio> listAereos = new List<ModelClasses.Servicio>();
            listAereos = DAL.ServicioDAL.GetServicioporTipo("Aéreo");
            //ddlAereos =
            ModelClasses.Servicio serv = new ModelClasses.Servicio();
            serv.Id = 0;
            listAereos2.Add(serv);
            GridAereos.DataSource = listAereos2;
            GridAereos.DataBind();

            var rows = GridAereos.Rows;
            
            foreach (GridViewRow row in rows)
            {
                
                DropDownList ddlaereos = (DropDownList)row.Cells[0].FindControl("ddlAereos");
                ddlaereos.Items.Clear();
                // <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
                ddlaereos.Items.Add("--Seleccione un aereo--");
                ddlaereos.DataSource = listAereos;
                ddlaereos.DataValueField = "Id";
                ddlaereos.DataTextField = "Nombre";
                ddlaereos.DataBind();
                
            }

            
        }

        protected void SaveNew_Click(object sender, EventArgs e)
        {

        }

        protected void SaveUpdat_Click(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }
        protected void New_Click(object sender, EventArgs e)
        {
            cleanField();
            LoadData();
            MultiView1.SetActiveView(View1);
        }

        private void LoadData()
        {
            //llenar grilla aereos
            List<ModelClasses.Servicio> listAereos = new List<ModelClasses.Servicio>();
            List<ModelClasses.Servicio> list = new List<ModelClasses.Servicio>();
            list = DAL.ServicioDAL.GetServicioporTipo("Aéreo");
            //ddlAereos =
            ModelClasses.Servicio serv = new ModelClasses.Servicio();
            serv.Id = 0;
            listAereos.Add(serv);
            GridAereos.DataSource = listAereos;
            GridAereos.DataBind();

            var rows = GridAereos.Rows;

            foreach (GridViewRow row in rows)
            {

                DropDownList ddlaereos = (DropDownList)row.Cells[0].FindControl("ddlAereos");
                ddlaereos.Items.Clear();
                // <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
                ddlaereos.Items.Add("--Seleccione un aereo--");
                ddlaereos.DataSource = list;
                ddlaereos.DataValueField = "Id";
                ddlaereos.DataTextField = "Nombre";
                ddlaereos.DataBind();

            }

            //llenar grilla Transfer
            List<ModelClasses.Servicio> listTrans = new List<ModelClasses.Servicio>();
            List<ModelClasses.Servicio> listT = new List<ModelClasses.Servicio>();
            list = DAL.ServicioDAL.GetServicioporTipo("Transfer");
            //ddlAereos =
            ModelClasses.Servicio servT = new ModelClasses.Servicio();
            serv.Id = 0;
            listTrans.Add(servT);
            GridTransfer.DataSource = listTrans;
            GridTransfer.DataBind();

            var rowsT = GridTransfer.Rows;

            foreach (GridViewRow row in rowsT)
            {

                DropDownList ddlTransfer = (DropDownList)row.Cells[0].FindControl("ddlTransfer");
                ddlTransfer.Items.Clear();
                // <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
                ddlTransfer.Items.Add("--Seleccione un Transfer--");
                ddlTransfer.DataSource = list;
                ddlTransfer.DataValueField = "Id";
                ddlTransfer.DataTextField = "Nombre";
                ddlTransfer.DataBind();

            }

            List<ModelClasses.Servicio> listServ = new List<ModelClasses.Servicio>();
            List<ModelClasses.Servicio> listS = new List<ModelClasses.Servicio>();
            list = DAL.ServicioDAL.GetServicioporTipo("");
            //ddlAereos =
            ModelClasses.Servicio servic = new ModelClasses.Servicio();
            serv.Id = 0;
            listServ.Add(servic);
            GridServicio.DataSource = listServ;
            GridServicio.DataBind();

            var rowsS = GridServicio.Rows;

            foreach (GridViewRow row in rowsS)
            {

                DropDownList ddlServicio = (DropDownList)row.Cells[0].FindControl("ddlServicio");
                ddlServicio.Items.Clear();
                // <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
                ddlServicio.Items.Add("--Seleccione un Servicio--");
                ddlServicio.DataSource = list;
                ddlServicio.DataValueField = "Id";
                ddlServicio.DataTextField = "Nombre";
                ddlServicio.DataBind();

            }

            List<ModelClasses.Servicio> listHotel= new List<ModelClasses.Servicio>();
            List<ModelClasses.Servicio> listH = new List<ModelClasses.Servicio>();
            list = DAL.ServicioDAL.GetServicioporTipo("");
            //ddlAereos =
            ModelClasses.Servicio serviH = new ModelClasses.Servicio();
            serv.Id = 0;
            listHotel.Add(serviH);
            GridHoteles.DataSource = listHotel;
            GridHoteles.DataBind();

            var rowsH = GridHoteles.Rows;

            foreach (GridViewRow row in rowsH)
            {

                DropDownList ddlServicio = (DropDownList)row.Cells[0].FindControl("ddlHotel");
                ddlServicio.Items.Clear();
                // <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
                ddlServicio.Items.Add("--Seleccione un Hotel--");
                ddlServicio.DataSource = list;
                ddlServicio.DataValueField = "Id";
                ddlServicio.DataTextField = "Nombre";
                ddlServicio.DataBind();

            }
        }

        private void cleanField()
        {
            
        }
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            //string sortExpression = e.SortExpression;
            //BindData();
            //var DataSource = (IList<ModelClasses.HotelPrecio>)Grid.DataSource;
            //switch (sortExpression)
            //{
            //    case "Name":
            //        DataSource = (from c in DataSource
            //                      orderby c.Name ascending
            //                      select c).ToList();
            //        break;
            //    case "Ciudad":
            //        DataSource = (from c in DataSource
            //                      orderby c.Ciudad ascending
            //                      select c).ToList();
            //        break;

            //}
            //Grid.DataSource = DataSource;
            //Grid.DataBind();

        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            //MultiView1.SetActiveView(View3);
            //int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            ////Grid.EditItemIndex = e.Item.ItemIndex;
            //LoadDataToEdit(id);
            //Carlar los textbox con los valores a editar

        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            //BindData();
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            Grid.EditItemIndex = -1;
            //BindData();
        }
       
        private void LoadDataToEdit(int Id)
        {
            //ModelClasses.HotelPrecio hotelprecioEdit = new ModelClasses.HotelPrecio();
            //Session["IDEDIT"] = Id;
            //hotelprecioEdit = DAL.HoltelPrecioDAL.GetOneById(Id);
            //ModelClasses.Hotel hotel = DAL.HotelesDAL.GetoneHotel(hotelprecioEdit.Hotel.Id);

            //List<ModelClasses.Hotel> hoteles = new List<ModelClasses.Hotel>();
            //hoteles = HotelesDAL.getAllHoteles();
            //ddlEdithotel.DataSource = hoteles;
            //ddlEdithotel.DataValueField = "Id";
            //ddlEdithotel.DataTextField = "Nombre";
            //ddlEdithotel.DataBind();
            //ddlEdithotel.SelectedValue = hotel.Id.ToString();
            //ddlEdithotel.Enabled = false;
            //TXTFechaDEdit.Text = hotelprecioEdit.FDesde.ToString("M/d/yyyy");
            //TXTFechaHEdit.Text = hotelprecioEdit.FHasta.ToString("M/d/yyyy");
            //TXTPesoEdit.Text = hotelprecioEdit.PrecioPeso.ToString();
            //TXTDolarEdit.Text = hotelprecioEdit.PrecioDolar.ToString();
            //TXTDetalleEdit.Text = hotelprecioEdit.NameHabitacion.ToString();

        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar" + "');", true);
            //ModelClasses.HotelPrecio deleteprecioH = new ModelClasses.HotelPrecio();
            //int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            //deleteprecioH.Id = id;
            //DAL.HoltelPrecioDAL.DeletePrecioHotel(deleteprecioH);
            //BindData();
            //MultiView1.SetActiveView(View2);

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //Grid.CurrentPageIndex = e.NewPageIndex;
            //BindData();
        }
        
       


    }
}