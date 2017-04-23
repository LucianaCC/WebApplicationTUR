using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;

namespace WebAppTUR.HotelPrecio
{
    public partial class HotelPrecio : System.Web.UI.Page
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
                else { Response.Redirect("~/index.aspx"); }

            }
        }
        private void BindData()
        {
            List<ModelClasses.HotelPrecio> ds = new List<ModelClasses.HotelPrecio>();
            ds = HoltelPrecioDAL.getAllHotelesPrecio();
            //Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        protected void New_Click(object sender, EventArgs e)
        {
            //clean
            cleanFields();
            MultiView1.SetActiveView(View1);

        }
        protected void Ciudad_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlCiudad.SelectedValue != "--Seleccione una Ciudad--")
            {
                List<ModelClasses.Hotel> hoteles = new List<ModelClasses.Hotel>();
                hoteles = HotelesDAL.GetHotelesporCiudad(Convert.ToInt32(ddlCiudad.SelectedValue));
                ddlHotel.DataSource = hoteles;
                ddlHotel.DataValueField = "Id";
                ddlHotel.DataTextField = "Nombre";
                ddlHotel.DataBind();
                ddlHotel.Items.Insert(0, "<-- Seleccione -->");
            }
            else { ddlHotel.Items.Clear(); }      

        }
        protected void SaveNew_Click(object sender, EventArgs e)
        {
            //Recorrer los textbox
            try
            {
                List<ModelClasses.HotelPrecio> list = getHotelPrecio();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        HoltelPrecioDAL.newHotelPrecio(item);
                    }
                    BindData();
                    MultiView1.SetActiveView(View2);
                    cleanFields();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
            
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
        }
        public List<ModelClasses.HotelPrecio> getHotelPrecio()
        {
            DateTime FDesde = Convert.ToDateTime(Fdesde.Text);
            DateTime FHasta = Convert.ToDateTime(Fhasta.Text);
           
                List<ModelClasses.HotelPrecio> list = new List<ModelClasses.HotelPrecio>();
                if (FDesde < FHasta)
                {
                    TXTError.Text = "";
                    #region Armado de precios
                    if (!String.IsNullOrEmpty(TXT1.Text))
                    {
                        
                            ModelClasses.HotelPrecio precio1 = new ModelClasses.HotelPrecio();
                            precio1.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                            precio1.NameHabitacion = TXT1.Text.Trim();
                            precio1.FDesde = Convert.ToDateTime(Fdesde.Text);
                            precio1.FHasta = Convert.ToDateTime(Fhasta.Text);
                            precio1.Name = precio1.Hotel.Nombre;
                            if (!String.IsNullOrEmpty(D1.Text) )
                            {
                                float numeroD = float.Parse(D1.Text, System.Globalization.NumberStyles.Float);
                                precio1.PrecioDolar = Convert.ToDecimal(numeroD);
                                
                            }
                            if (!String.IsNullOrEmpty(P1.Text))
                            {
                               float numeroP = float.Parse(P1.Text, System.Globalization.NumberStyles.Float);
                               precio1.PrecioPeso = Convert.ToDecimal(numeroP);
                            }
                            
                            
                            list.Add(precio1);
                        
                    }
                    if (!String.IsNullOrEmpty(TXT2.Text))
                    {
                        ModelClasses.HotelPrecio precio2 = new ModelClasses.HotelPrecio();
                        precio2.NameHabitacion = TXT2.Text.Trim();
                        precio2.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio2.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio2.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio2.Name = precio2.Hotel.Nombre;


                        if (!String.IsNullOrEmpty(D2.Text))
                        {
                            float numeroD = float.Parse(D2.Text, System.Globalization.NumberStyles.Float);
                            precio2.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P2.Text))
                        {
                            float numeroP = float.Parse(P2.Text, System.Globalization.NumberStyles.Float);
                            precio2.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio2);
                    }
                    if (!String.IsNullOrEmpty(TXT3.Text))
                    {
                        ModelClasses.HotelPrecio precio3 = new ModelClasses.HotelPrecio();
                        precio3.NameHabitacion = TXT3.Text.Trim();
                        precio3.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio3.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio3.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio3.Name = precio3.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D3.Text))
                        {
                            float numeroD = float.Parse(D3.Text, System.Globalization.NumberStyles.Float);
                            precio3.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P3.Text))
                        {
                            float numeroP = float.Parse(P3.Text, System.Globalization.NumberStyles.Float);
                            precio3.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio3);
                    }
                    if (!String.IsNullOrEmpty(TXT4.Text))
                    {
                        ModelClasses.HotelPrecio precio4 = new ModelClasses.HotelPrecio();
                        precio4.NameHabitacion = TXT4.Text.Trim();
                        precio4.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio4.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio4.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio4.Name = precio4.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D4.Text))
                        {
                            float numeroD = float.Parse(D4.Text, System.Globalization.NumberStyles.Float);
                            precio4.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P4.Text))
                        {
                            float numeroP = float.Parse(P4.Text, System.Globalization.NumberStyles.Float);
                            precio4.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio4);
                    }
                    if (!String.IsNullOrEmpty(TXT5.Text))
                    {
                        ModelClasses.HotelPrecio precio5 = new ModelClasses.HotelPrecio();
                        precio5.NameHabitacion = TXT5.Text.Trim();
                        precio5.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio5.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio5.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio5.Name = precio5.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D5.Text))
                        {
                            float numeroD = float.Parse(D5.Text, System.Globalization.NumberStyles.Float);
                            precio5.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P5.Text))
                        {
                            float numeroP = float.Parse(P5.Text, System.Globalization.NumberStyles.Float);
                            precio5.PrecioPeso = Convert.ToDecimal(numeroP);
                        }

                        list.Add(precio5);
                    }
                    if (!String.IsNullOrEmpty(TXT6.Text))
                    {
                        ModelClasses.HotelPrecio precio6 = new ModelClasses.HotelPrecio();
                        precio6.NameHabitacion = TXT6.Text.Trim();
                        precio6.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio6.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio6.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio6.Name = precio6.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D6.Text))
                        {
                            float numeroD = float.Parse(D6.Text, System.Globalization.NumberStyles.Float);
                            precio6.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P6.Text))
                        {
                            float numeroP = float.Parse(P6.Text, System.Globalization.NumberStyles.Float);
                            precio6.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio6);
                    }
                    if (!String.IsNullOrEmpty(TXT7.Text))
                    {
                        ModelClasses.HotelPrecio precio7 = new ModelClasses.HotelPrecio();
                        precio7.NameHabitacion = TXT7.Text.Trim();
                        precio7.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio7.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio7.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio7.Name = precio7.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D7.Text))
                        {
                            float numeroD = float.Parse(D7.Text, System.Globalization.NumberStyles.Float);
                            precio7.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P7.Text))
                        {
                            float numeroP = float.Parse(P7.Text, System.Globalization.NumberStyles.Float);
                            precio7.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio7);
                    }
                    if (!String.IsNullOrEmpty(TXT8.Text))
                    {
                        ModelClasses.HotelPrecio precio8 = new ModelClasses.HotelPrecio();
                        precio8.NameHabitacion = TXT8.Text.Trim();
                        precio8.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio8.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio8.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio8.Name = precio8.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D8.Text))
                        {
                            float numeroD = float.Parse(D8.Text, System.Globalization.NumberStyles.Float);
                            precio8.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P8.Text))
                        {
                            float numeroP = float.Parse(P8.Text, System.Globalization.NumberStyles.Float);
                            precio8.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio8);
                    }
                    if (!String.IsNullOrEmpty(TXT9.Text))
                    {
                        ModelClasses.HotelPrecio precio9 = new ModelClasses.HotelPrecio();
                        precio9.NameHabitacion = TXT9.Text.Trim();
                        precio9.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio9.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio9.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio9.Name = precio9.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D9.Text))
                        {
                            float numeroD = float.Parse(D9.Text, System.Globalization.NumberStyles.Float);
                            precio9.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P9.Text))
                        {
                            float numeroP = float.Parse(P9.Text, System.Globalization.NumberStyles.Float);
                            precio9.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio9);
                    }
                    if (!String.IsNullOrEmpty(TXT10.Text))
                    {
                        ModelClasses.HotelPrecio precio10 = new ModelClasses.HotelPrecio();
                        precio10.NameHabitacion = TXT10.Text.Trim();
                        precio10.Hotel = HotelesDAL.GetoneHotel(Convert.ToInt32(ddlHotel.SelectedValue));
                        precio10.FDesde = Convert.ToDateTime(Fdesde.Text);
                        precio10.FHasta = Convert.ToDateTime(Fhasta.Text);
                        precio10.Name = precio10.Hotel.Nombre;
                        if (!String.IsNullOrEmpty(D10.Text))
                        {
                            float numeroD = float.Parse(D10.Text, System.Globalization.NumberStyles.Float);
                            precio10.PrecioDolar = Convert.ToDecimal(numeroD);

                        }
                        if (!String.IsNullOrEmpty(P10.Text))
                        {
                            float numeroP = float.Parse(P10.Text, System.Globalization.NumberStyles.Float);
                            precio10.PrecioPeso = Convert.ToDecimal(numeroP);
                        }
                        list.Add(precio10);
                    }
                    #endregion
                }
                else { TXTError.Text = " *Seleccione una fecha desde mayor que la fecha hasta.";
                TXTError.ForeColor = System.Drawing.Color.Red;
                
                }
                return list;
            

        }
        public void cleanFields()
        {
            TXTError.Text = "";
            TXT1.Text = "";
            TXT2.Text = "";
            TXT3.Text = "";
            TXT4.Text = "";
            TXT5.Text = "";
            TXT6.Text = "";
            TXT7.Text = "";
            TXT8.Text = "";
            TXT9.Text = "";
            TXT10.Text = "";
            P1.Text = "";
            P2.Text = "";
            P3.Text = "";
            P4.Text = "";
            P5.Text = "";
            P6.Text = "";
            P7.Text = "";
            P8.Text = "";
            P9.Text = "";
            P10.Text = "";
            D1.Text = "";
            D2.Text = "";
            D3.Text = "";
            D4.Text = "";
            D5.Text = "";
            D6.Text = "";
            D7.Text = "";
            D8.Text = "";
            D9.Text = "";
            D10.Text = "";
            Fdesde.Text = "";
            Fhasta.Text = "";
            LoadDDLCiudad();
        }
        
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            MultiView1.SetActiveView(View3);
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            //Grid.EditItemIndex = e.Item.ItemIndex;
            LoadDataToEdit(id);
            //Carlar los textbox con los valores a editar

        }

        private void LoadDataToEdit(int Id)
        {
            ModelClasses.HotelPrecio hotelprecioEdit = new ModelClasses.HotelPrecio();
            Session["IDEDIT"] = Id;            
            hotelprecioEdit = DAL.HoltelPrecioDAL.GetOneById(Id);
            ModelClasses.Hotel hotel = DAL.HotelesDAL.GetoneHotel(hotelprecioEdit.Hotel.Id);

            List<ModelClasses.Hotel> hoteles = new List<ModelClasses.Hotel>();
            hoteles = HotelesDAL.getAllHoteles();
            ddlEdithotel.DataSource = hoteles;
            ddlEdithotel.DataValueField = "Id";
            ddlEdithotel.DataTextField = "Nombre";
            ddlEdithotel.DataBind();
            ddlEdithotel.SelectedValue = hotel.Id.ToString();
            ddlEdithotel.Enabled = false;
            TXTFechaDEdit.Text = hotelprecioEdit.FDesde.ToString("M/d/yyyy");
            TXTFechaHEdit.Text = hotelprecioEdit.FHasta.ToString("M/d/yyyy");
            TXTPesoEdit.Text = hotelprecioEdit.PrecioPeso.ToString();
            TXTDolarEdit.Text = hotelprecioEdit.PrecioDolar.ToString();
            TXTDetalleEdit.Text = hotelprecioEdit.NameHabitacion.ToString();
            
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar" + "');", true);
            ModelClasses.HotelPrecio deleteprecioH = new ModelClasses.HotelPrecio();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            deleteprecioH.Id = id;
            DAL.HoltelPrecioDAL.DeletePrecioHotel(deleteprecioH);
            BindData();
            MultiView1.SetActiveView(View2);

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        
        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(Session["IDEDIT"]);
            DAL.PrecioHotelDetail precio1 = new DAL.PrecioHotelDetail();
            precio1.Id = id;
            //precio1.IdHotel = (Convert.ToInt32(ddlHotel.SelectedValue));
            precio1.TipoHabitacion = TXTDetalleEdit.Text.Trim();
            precio1.FechaDesde = Convert.ToDateTime(TXTFechaDEdit.Text);
            precio1.FechaHasta = Convert.ToDateTime(TXTFechaHEdit.Text);
            if (!String.IsNullOrEmpty(TXTDolarEdit.Text))
            {
                float numeroD = float.Parse(TXTDolarEdit.Text, System.Globalization.NumberStyles.Float);
                precio1.PrecioDolar = Convert.ToDecimal(numeroD);

            }
            if (!String.IsNullOrEmpty(TXTPesoEdit.Text))
            {
                float numeroP = float.Parse(TXTPesoEdit.Text, System.Globalization.NumberStyles.Float);
                precio1.PrecioPeso = Convert.ToDecimal(numeroP);
            }
            HoltelPrecioDAL.EditPrecioHotel(precio1);
            Grid.EditItemIndex = -1;
            BindData();
            MultiView1.SetActiveView(View2);
        }

        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;
            BindData();
            var DataSource = (IList<ModelClasses.HotelPrecio>)Grid.DataSource;
            switch (sortExpression)
            {
                case "Name":
                    DataSource = (from c in DataSource
                                  orderby c.Name ascending
                                  select c).ToList();
                    break;
                case "Ciudad":
                    DataSource = (from c in DataSource
                                  orderby c.Ciudad ascending
                                  select c).ToList();
                    break;
               
            }
            Grid.DataSource = DataSource;
            Grid.DataBind();

        }

       
    }
}