using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;
using ModelClasses;
using DAL;

namespace WebAppTUR.Hoteles
{
    public partial class HotelEditDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["User"] != "")
                {
                    Filldata();
                    string ID = Request.QueryString["IDHotel"];
                    if (!String.IsNullOrEmpty(ID))
                    {
                        Session["Hotel"] = ID;
                        LoadData_ToUpdate(ID);
                    }

                    else
                    {
                        clean();
                        Session["Hotel"] = null;
                    }
                }
                else { Response.Redirect("~/index.aspx"); }

            }

        }

        public void SaveNew_Click(object sender, EventArgs e)
        {

            ModelClasses.Hotel hotel_ = new ModelClasses.Hotel();
            hotel_.Ciudad = DAL.CiudadesDAL.GetOneById(Convert.ToInt32(DdlCiudad.SelectedValue));
            hotel_.Categoria = DdLCategorias.SelectedValue.ToString().Trim();
            hotel_.Nombre = TXTnombre.Text.ToString().Trim();
            hotel_.Direcion = TXTDireccion.Text.ToString().Trim();
            hotel_.Telefono = TXTTelefono.Text.ToString().Trim();
            hotel_.Contacto = TXTContacto.Text.ToString().Trim();
            hotel_.Email = TXTEmail.Text.ToString().Trim();
            hotel_.NombreBco = TXTBcoNombre.Text.ToString().Trim();
            hotel_.NumeroCuenta = TXTCta.Text.ToString().Trim();
            hotel_.DireccionBco = TXTDireccion.Text.ToString().Trim();
            hotel_.Cuit = TXTCuit.Text.ToString().Trim();
            hotel_.CBU = TXTCBU.Text.ToString().Trim();
            hotel_.ObservacionBco = TXTObs.Text.ToString().Trim();
            hotel_.Observacion = TXTObsHotel.Text.ToString().Trim();
            hotel_.CheckIn = DdpCHIN.SelectedValue.ToString() + "/" + DdpCHINMin.SelectedValue.ToString();
            hotel_.CheckOut = DdpCHout.SelectedValue.ToString() + "/" + DdpCHoutMin.SelectedValue.ToString();
            hotel_.CheckIn.Trim();
            hotel_.CheckOut.Trim();
            if (Session["Hotel"] != null)
            {
                hotel_.Id = Convert.ToInt32(Session["Hotel"].ToString());
                HotelesDAL.EditHotel(hotel_);
                Session["Hotel"] = null;
                Response.Redirect("~/Hoteles/HotelABM.aspx");
            }
            else
            {
                HotelesDAL.newhotel(hotel_);
                Response.Redirect("~/Hoteles/HotelABM.aspx");
            }

            clean();
        }
        private void Filldata()
        {

            DdlCiudad.DataSource = CiudadesDAL.getAllCiudades();
            DdlCiudad.DataValueField = "Id";
            DdlCiudad.DataTextField = "CodigoInterno";
            DdlCiudad.DataBind();
            DdlCiudad.Items.Insert(0, "<-- Seleccione -->");

            List<string> Categorias = new List<string>();
            Categorias.Add("SUPERIOR");
            Categorias.Add("INTERMEDIO");
            Categorias.Add("STANDARD");
            DdLCategorias.DataSource = Categorias;
            DdLCategorias.DataBind();
            DdLCategorias.Items.Insert(0, "<-- Seleccione -->");


            List<string> checkinout = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                string hour = i.ToString();
                checkinout.Add(hour);
            }
            List<string> checkinoutmin = new List<string>();
            for (int i = 0; i < 60; i++)
            {
                string min = i.ToString();
                checkinoutmin.Add(min);
            }

            DdpCHIN.DataSource = checkinout;
            DdpCHIN.DataBind();
            DdpCHout.DataSource = checkinout;
            DdpCHout.DataBind();
            DdpCHINMin.DataSource = checkinoutmin;
            DdpCHINMin.DataBind();
            DdpCHoutMin.DataSource = checkinoutmin;
            DdpCHoutMin.DataBind();



        }


        public void Cancel_Click(object sender, EventArgs e)
        {
            clean();
            Filldata();
            Response.Redirect("~/Hoteles/HotelABM.aspx");

        }
        protected void clean()
        {


            TXTnombre.Text = "";
            TXTDireccion.Text = "";
            TXTTelefono.Text = "";
            TXTContacto.Text = "";
            TXTEmail.Text = "";
            TXTBcoNombre.Text = "";
            TXTCta.Text = "";
            TXTDireccion.Text = "";
            TXTCuit.Text = "";
            TXTCBU.Text = "";
            TXTObs.Text = "";
            TXTObsHotel.Text = "";

        }
        protected void SaveUpdat_Click(object sender, EventArgs e)
        {
            ModelClasses.Hotel hotel_ = new ModelClasses.Hotel();
            hotel_.Id = Convert.ToInt32(Session["Hotel"].ToString());
            hotel_.Ciudad = CiudadesDAL.GetOneById(Convert.ToInt32(DdlCiudad.SelectedValue.ToString()));// DdlCiudad.SelectedValue.ToString();
            hotel_.Categoria = DdLCategorias.SelectedValue.ToString().Trim();
            hotel_.Nombre = TXTnombre.Text.ToString().Trim();
            hotel_.Direcion = TXTDireccion.Text.ToString().Trim();
            hotel_.Telefono = TXTTelefono.Text.ToString().Trim();
            hotel_.Contacto = TXTContacto.Text.ToString().Trim();
            hotel_.Email = TXTEmail.Text.ToString().Trim();
            hotel_.NombreBco = TXTBcoNombre.Text.ToString().Trim();
            hotel_.NumeroCuenta = TXTCta.Text.ToString().Trim();
            hotel_.DireccionBco = TXTDireccion.Text.ToString().Trim();
            hotel_.Cuit = TXTCuit.Text.ToString().Trim();
            hotel_.CBU = TXTCBU.Text.ToString().Trim();
            hotel_.ObservacionBco = TXTObs.Text.ToString().Trim();
            hotel_.Observacion = TXTObsHotel.Text.ToString().Trim();
            hotel_.CheckIn = DdpCHIN.SelectedValue.ToString() + "/" + DdpCHINMin.SelectedValue.ToString();
            hotel_.CheckOut = DdpCHout.SelectedValue.ToString() + "/" + DdpCHoutMin.SelectedValue.ToString();
            hotel_.CheckIn.Trim();
            hotel_.CheckOut.Trim();

            HotelesDAL.EditHotel(hotel_);
            clean();
        }

        public void LoadData_ToUpdate(string ID)
        {

            ModelClasses.Hotel hotel_ = HotelesDAL.GetoneHotel(Convert.ToInt32(ID));

            DdlCiudad.SelectedValue = hotel_.Ciudad.Id.ToString();
            DdLCategorias.SelectedValue = hotel_.Categoria.Trim();
            TXTnombre.Text = hotel_.Nombre;
            TXTDireccion.Text = hotel_.Direcion;
            TXTTelefono.Text = hotel_.Telefono;
            TXTContacto.Text = hotel_.Contacto;
            TXTEmail.Text = hotel_.Email;
            TXTBcoNombre.Text = hotel_.NombreBco;
            TXTCta.Text = hotel_.NumeroCuenta;
            TXTDireccion.Text = hotel_.DireccionBco;
            TXTCuit.Text = hotel_.Cuit;
            TXTCBU.Text = hotel_.CBU;
            TXTObs.Text = hotel_.ObservacionBco;
            TXTObsHotel.Text = hotel_.Observacion;
            string[] Chin = hotel_.CheckIn.Split('/');
            string[] ChOu = hotel_.CheckOut.Split('/');
            string cheInH = Chin[0];
            string cheInM = Chin[1];
            string cheOuH = ChOu[0];
            string cheOuM = ChOu[1];

            DdpCHIN.SelectedValue = cheInH.Trim();
            DdpCHout.SelectedValue = cheOuH.Trim();
            DdpCHINMin.SelectedValue = cheInM.Trim();
            DdpCHoutMin.SelectedValue = cheOuM.Trim();


        }
    }
}