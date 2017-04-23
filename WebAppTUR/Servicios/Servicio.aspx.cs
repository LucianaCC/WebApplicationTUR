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
    public partial class Servicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["User"] != null && Session["User"] != "")
                {
                    Page.Form.Attributes.Add("enctype", "multipart/form-data");
                    MultiView1.SetActiveView(View2);
                    Image2.Visible = false;
                    BtnDelImg.Visible = false;
                    BTNSaveUpdat.Visible = false;
                    BindData();
                  

                }
                else { Response.Redirect("~/index.aspx"); }

                
            }

        }
        protected void Actividad__OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlActividad.SelectedValue == "Transfer")
            {
                LabelTransfer.Visible = true;
                ddlTipoTransfer.Visible = true;
            }
            else
            {
                LabelTransfer.Visible = false;
                ddlTipoTransfer.Visible = false;
            }

        }

      
        private void BindData()
        {
            List<ModelClasses.Servicio> ds = new List<ModelClasses.Servicio>();
            ds = ServicioDAL.getAllServicio();
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
            LabelTransfer.Visible = false;
            ddlTipoTransfer.Visible = false;
            ddlTipoTransfer.DataSource = getTransfer();
            ddlTipoTransfer.DataBind();
            ddlActividad.DataSource = getareas();
            ddlActividad.DataBind();
            ddlActividad.Items.Insert(0, "<-- Seleccione -->");

            LoadDDLCiudades();

            List<string> TimeHours = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                string hour = i.ToString();
                TimeHours.Add(hour);
            }
            List<string> Timemin = new List<string>();
            for (int i = 0; i < 60; i++)
            {
                string min = i.ToString();
                Timemin.Add(min);
            }

            DdlHDestino.DataSource = TimeHours;
            DdlHDestino.DataBind();
            DdlHOrigen.DataSource = TimeHours;
            DdlHOrigen.DataBind();
            DdlMinOrigen.DataSource = Timemin;
            DdlMinOrigen.DataBind();
            DdlMinDestino.DataSource = Timemin;
            DdlMinDestino.DataBind();
            ddlOperador.Enabled = false;
            
        }
        private void LoadDDLCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            ciudades = CiudadesDAL.getAllCiudades();

            
            ddlCiudad.DataSource = ciudades;
            ddlCiudad.DataValueField = "Id";
            ddlCiudad.DataTextField = "CodigoInterno";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, "<-- Seleccione -->");

            ddlCiudadOrigen.DataSource = ciudades;
            ddlCiudadOrigen.DataValueField = "Id";
            ddlCiudadOrigen.DataTextField = "CodigoInterno";
            ddlCiudadOrigen.DataBind();
            ddlCiudadOrigen.Items.Insert(0, "<-- Seleccione -->");

            ddlCiudadDestino.DataSource = ciudades;
            ddlCiudadDestino.DataValueField = "Id";
            ddlCiudadDestino.DataTextField = "CodigoInterno";
            ddlCiudadDestino.DataBind();
            ddlCiudadDestino.Items.Insert(0, "<-- Seleccione -->");
        }       
        public List<string> getareas()
        {

            List<string> valuesAreas = new List<string>();
            valuesAreas.Add("Aéreo");
            valuesAreas.Add("Bus");
            valuesAreas.Add("Comida");
            valuesAreas.Add("Costo");
            valuesAreas.Add("Crucero");
            valuesAreas.Add("Navegación");
            valuesAreas.Add("Otro");
            valuesAreas.Add("Ticket");
            valuesAreas.Add("Tour");
            valuesAreas.Add("Transfer");
            valuesAreas.Add("Guía");
            valuesAreas.Add("Trekking");
            valuesAreas.Add("Tour");
            valuesAreas.Add("Trekking Cerrado");
            valuesAreas.Add("Tren");
            valuesAreas.Add("Turismo Aventura");

            return valuesAreas;


        }
        public List<string> getTransfer()
        {

            List<string> transfer = new List<string>();
            transfer.Add("NONE");
            transfer.Add("APT-HTL");
            transfer.Add("HTL-APT");
            transfer.Add("TRM-HTL");
            transfer.Add("HTL-TRM");
            transfer.Add("APT-TRM");
            transfer.Add("TRM-APT");
            transfer.Add("APT-APT");
            transfer.Add("HTL-TRM");
            transfer.Add("HTL-PTO");
            transfer.Add("PTO-HTL");
            transfer.Add("HTL-HTL");
            transfer.Add("PTO-APT");
            transfer.Add("APT-PTO");
            transfer.Add("PTO-TRM");
            transfer.Add("TRM-PTO");

            return transfer;


        }
        private void CleanField()
        {
            BindData();
            TXTnombre.Text = string.Empty;
            TXTObs.Text = string.Empty;
            txtDias.Text = string.Empty;
            ddlOperador.DataSource = String.Empty;
            ddlOperador.DataBind();
            GridDetalleLista.DataSource = null;
            GridDetalleLista.DataBind();
            IDImage.Text = "";
            IDImage.Visible = false;
            Image2.ImageUrl = "";
            FileUpload1.Visible = true;
            BtnAddImg.Visible = true;
            BtnDelImg.Visible = false;
            ErrorMSG.Text = "";
            ErrorMSG.Visible = false;
           
        }

        protected void Ciudad_OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            ddlOperador.Enabled = true;
            List<ModelClasses.Operador> operadores = new List<ModelClasses.Operador>();
            operadores = OperadorDAL.GetOperadorporCiudad(Convert.ToInt32(ddlCiudad.SelectedValue));

            ddlOperador.DataSource = operadores;
            ddlOperador.DataValueField = "Id";
            ddlOperador.DataTextField = "Nombre";
            ddlOperador.DataBind();
            ddlOperador.Items.Insert(0, "<-- Seleccione -->"); 
            
        }

        protected void SaveUpdat_Click(object sender, EventArgs e)
        {
            ModelClasses.Servicio servicioedit = new ModelClasses.Servicio();
            servicioedit.Id = Convert.ToInt32(Session["ID"]);
            servicioedit.Nombre = TXTnombre.Text;
            servicioedit.ObservacionServicio = TXTObs.Text;
            servicioedit.Actividad = ddlActividad.SelectedValue;
            servicioedit.DiasCant = txtDias.Text;
            servicioedit.TipoTranfer = ddlTipoTransfer.SelectedValue;
            servicioedit.CiudadOperador = CiudadesDAL.GetOneById(Convert.ToInt32(ddlCiudad.SelectedItem.Value));
            servicioedit.Operador = OperadorDAL.GetoneOperador(Convert.ToInt32(ddlOperador.SelectedValue));
            servicioedit.CiudadO = CiudadesDAL.GetOneById(Convert.ToInt32(ddlCiudadOrigen.SelectedValue));
            servicioedit.CiudadD = CiudadesDAL.GetOneById(Convert.ToInt32(ddlCiudadDestino.SelectedValue));
            servicioedit.HoraSalida = DdlHOrigen.SelectedValue.ToString().Trim() + ":" + DdlMinOrigen.SelectedValue.ToString().Trim();
            servicioedit.HoraLlegada = DdlHDestino.SelectedValue.ToString().Trim() + ":" + DdlMinDestino.SelectedValue.ToString().Trim();
            if (!String.IsNullOrEmpty(IDImage.Text)) {
                servicioedit.IdImagen = Convert.ToInt32(IDImage.Text);
            }
            ServicioDetalleIdioma detalleser = new ServicioDetalleIdioma();
            detalleser.IdServicio = servicioedit.Id;
            servicioedit.DetalleIdiomas = getAllDetalleIdiomaEditado();
            ServicioDAL.EditServicio(servicioedit);
            Session["ID"] = "";
            BindData();
            CleanField();
            MultiView1.SetActiveView(View2);



        }
        protected void SaveNew_Click(object sender, EventArgs e)
        {
            Session["ID"] = "";
            if (TXTnombre.Text != "")
            {
                ModelClasses.Servicio servicioedit = new ModelClasses.Servicio();
                servicioedit.Nombre = TXTnombre.Text;
                servicioedit.Actividad = ddlActividad.SelectedValue;
                servicioedit.DiasCant = txtDias.Text;
                servicioedit.ObservacionServicio = TXTObs.Text;
                servicioedit.TipoTranfer = ddlTipoTransfer.SelectedValue;
                servicioedit.CiudadOperador = CiudadesDAL.GetOneById(Convert.ToInt32(ddlCiudad.SelectedItem.Value));
                servicioedit.Operador = OperadorDAL.GetoneOperador(Convert.ToInt32(ddlOperador.SelectedValue));
                servicioedit.CiudadO = CiudadesDAL.GetOneById(Convert.ToInt32(ddlCiudadOrigen.SelectedValue));
                servicioedit.CiudadD = CiudadesDAL.GetOneById(Convert.ToInt32(ddlCiudadDestino.SelectedValue));
                servicioedit.HoraSalida = DdlHOrigen.SelectedValue.ToString().Trim() + ":" + DdlMinOrigen.SelectedValue.ToString().Trim();
                servicioedit.HoraLlegada = DdlHDestino.SelectedValue.ToString().Trim() + ":" + DdlMinDestino.SelectedValue.ToString().Trim();
                if (!String.IsNullOrEmpty(IDImage.Text))
                {
                    servicioedit.IdImagen = Convert.ToInt32(IDImage.Text);
                }

                int IdNewServ = ServicioDAL.newServicio(servicioedit);

                List<ServicioDetalleIdioma> list = new List<ServicioDetalleIdioma>();
                list = getAllDetalleIdioma();
                foreach (var _item in list)
                {
                    ServicioDetalleIdioma item = new ServicioDetalleIdioma();
                    item.IdServicio = IdNewServ;
                    item.NombreES = _item.NombreES;
                    item.DescripcionEs = _item.DescripcionEs;
                    item.NombrePT = _item.NombrePT;
                    item.DescripcionPT = _item.DescripcionPT;
                    item.NombreEN = _item.NombreEN;
                    item.DescripcionEN = _item.DescripcionEN;
                    item.NombreIT = _item.NombreIT;
                    item.DescripcionIT = _item.DescripcionIT;
                    item.NumDia = _item.NumDia;
                    ServicioDAL.newDetServ(item);
                }
                BindData();
                CleanField();
                MultiView1.SetActiveView(View2);

            }



        }
        protected void New_Click(object sender, EventArgs e)
        {
            Session["ID"] = "";
            BTNSaveUpdat.Visible = false;
            BTNSavenew.Visible = true;
            MultiView1.Visible = true;
            btnGenerarTabla.Visible = true;
            txtDias.Enabled = true;
            ddlActividad.Enabled = true;
            ddlTipoTransfer.Enabled = true;
            ddlCiudad.Enabled = true;
            ddlOperador.Enabled = true;
            ddlCiudadOrigen.Enabled = true;
            ddlCiudadDestino.Enabled = true;
            NumericUpDownExtender1.Enabled = true;
            CleanField();
            MultiView1.SetActiveView(View1);
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            CleanField();
            MultiView1.SetActiveView(View2);

        }

        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            BTNSavenew.Visible = false;
            BTNSaveUpdat.Visible = true;
            btnGenerarTabla.Visible = false;
            txtDias.Enabled = false;

           

            NumericUpDownExtender1.Enabled = false;
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Session["ID"] = id;
            ModelClasses.Servicio servicioedit = new ModelClasses.Servicio();
            servicioedit = ServicioDAL.GetoneServicio(id);
            MultiView1.SetActiveView(View1);
            TXTnombre.Text = servicioedit.Nombre;
            ddlActividad.SelectedValue = servicioedit.Actividad;
            txtDias.Text = servicioedit.DiasCant.ToString();
            ddlTipoTransfer.SelectedValue = servicioedit.TipoTranfer;
            ddlCiudad.SelectedValue = servicioedit.CiudadOperador.Id.ToString();
            ddlOperador.Enabled = true;
            List<ModelClasses.Operador> operadores = new List<ModelClasses.Operador>();
            operadores = OperadorDAL.GetOperadorporCiudad(Convert.ToInt32(ddlCiudad.SelectedValue));
            ddlOperador.DataSource = operadores;
            ddlOperador.DataValueField = "Id";
            ddlOperador.DataTextField = "Nombre";
            ddlOperador.DataBind();
            if (operadores.Contains(servicioedit.Operador))
            {
                ddlOperador.SelectedValue = servicioedit.Operador.Id.ToString();
            }
            ddlCiudadOrigen.SelectedValue = servicioedit.CiudadO.Id.ToString();
            ddlCiudadDestino.SelectedValue = servicioedit.CiudadD.Id.ToString();
            string[] HOrigen = servicioedit.HoraSalida.Split(':');
            string[] HDestino = servicioedit.HoraLlegada.Split(':');
            DdlHOrigen.SelectedValue = HOrigen[0];
            DdlMinOrigen.SelectedValue = HOrigen[1];
            DdlHDestino.SelectedValue = HDestino[0];
            DdlMinDestino.SelectedValue = HDestino[1];

            if (servicioedit.IdImagen > 0)
            {
                ModelClasses.Imagen imag = ImagenesDAL.GetOneById(servicioedit.IdImagen);
                LoadPicture(imag.Image, imag.Id);
            }

            GridDetalleLista.DataSource = servicioedit.DetalleIdiomas;
            GridDetalleLista.DataBind();
            ddlTipoTransfer.Enabled = false;
            ddlCiudad.Enabled = false;
            ddlOperador.Enabled = false;
            ddlCiudadOrigen.Enabled = false;
            ddlCiudadDestino.Enabled = false;
            ddlActividad.Enabled = false;
            
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar el servicio" + "');", true);
            DAL.Servicio deleteServ = new DAL.Servicio();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            deleteServ.Id = id;
            ServicioDAL.DeleteServicio(deleteServ);
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
        protected void DeleteDetalle_Click(object sender, EventArgs e)
        {


        }
        protected void GenerarTabla(object sender, EventArgs e)
        {
            List<ServicioDetalleIdioma> detail = new List<ServicioDetalleIdioma>();
            int rows = Convert.ToInt32(txtDias.Text);

            for (int i = 1; i <= rows; i++)
            {
                ServicioDetalleIdioma detalle = new ServicioDetalleIdioma();
                detalle.Id = 0;
                detalle.NombreES = "";
                detalle.DescripcionEs = "";
                detalle.NombrePT = "";
                detalle.DescripcionPT = "";
                detalle.NombreEN = "";
                detalle.DescripcionEN = "";
                detalle.NombreIT = "";
                detalle.DescripcionIT = "";
                detalle.NumDia = i;
                detail.Add(detalle);
            }
            GridDetalleLista.DataSource = detail;
            GridDetalleLista.DataBind();

        }
        protected List<ServicioDetalleIdioma> getAllDetalleIdioma()
        {

            List<ServicioDetalleIdioma> detail = new List<ServicioDetalleIdioma>();
            var rows = GridDetalleLista.Rows;

            foreach (GridViewRow row in rows)
            {
                ServicioDetalleIdioma detalle = new ServicioDetalleIdioma();
                //(TextBox)row.Cells[0].FindControl("txtTipoPrecio1");
                TextBox NomES = (TextBox)row.Cells[0].FindControl("NombreES");
                detalle.NombreES = NomES.Text;
                TextBox DescnEs = (TextBox)row.Cells[0].FindControl("DescripcionEs");
                detalle.DescripcionEs = DescnEs.Text;
                TextBox NomPT = (TextBox)row.Cells[0].FindControl("NombrePT");
                detalle.NombrePT = NomPT.Text;
                TextBox DescnPT = (TextBox)row.Cells[0].FindControl("DescripcionPT");
                detalle.DescripcionPT = DescnPT.Text;
                TextBox NomEN = (TextBox)row.Cells[0].FindControl("NombreEN");
                detalle.NombreEN = NomEN.Text;
                TextBox DescnEN = (TextBox)row.Cells[0].FindControl("DescripcionEN");
                detalle.DescripcionEN = DescnEN.Text;
                TextBox NomIT = (TextBox)row.Cells[0].FindControl("NombreIT");
                detalle.NombreIT = NomIT.Text;
                TextBox DescnIT = (TextBox)row.Cells[0].FindControl("DescripcionIT");
                detalle.DescripcionIT = DescnIT.Text;
                Label numerodia = (Label)row.Cells[0].FindControl("txtNDia");
                detalle.NumDia = Convert.ToInt32(numerodia.Text);
                int idDet;
                Label IdDet = (Label)row.Cells[0].FindControl("txtIdDet");
                idDet = Convert.ToInt32(IdDet.Text);
                if (idDet > 0)
                {
                    detalle.Id = idDet;
                
                }
                //int IdServ = Convert.ToInt32(Session["ID"]);
                //if (IdServ > 0)
                //{
                //    detalle.IdServicio = IdServ;

                //}
                // detalle.NumDia = 1;
                detail.Add(detalle);
            }
            return detail;

        }

        protected List<ServicioDetalleIdioma> getAllDetalleIdiomaEditado()
        {

            List<ServicioDetalleIdioma> detail = new List<ServicioDetalleIdioma>();
            var rows = GridDetalleLista.Rows;

            foreach (GridViewRow row in rows)
            {
                ServicioDetalleIdioma detalle = new ServicioDetalleIdioma();
                //(TextBox)row.Cells[0].FindControl("txtTipoPrecio1");
                TextBox NomES = (TextBox)row.Cells[0].FindControl("NombreES");
                detalle.NombreES = NomES.Text;
                TextBox DescnEs = (TextBox)row.Cells[0].FindControl("DescripcionEs");
                detalle.DescripcionEs = DescnEs.Text;
                TextBox NomPT = (TextBox)row.Cells[0].FindControl("NombrePT");
                detalle.NombrePT = NomPT.Text;
                TextBox DescnPT = (TextBox)row.Cells[0].FindControl("DescripcionPT");
                detalle.DescripcionPT = DescnPT.Text;
                TextBox NomEN = (TextBox)row.Cells[0].FindControl("NombreEN");
                detalle.NombreEN = NomEN.Text;
                TextBox DescnEN = (TextBox)row.Cells[0].FindControl("DescripcionEN");
                detalle.DescripcionEN = DescnEN.Text;
                TextBox NomIT = (TextBox)row.Cells[0].FindControl("NombreIT");
                detalle.NombreIT = NomIT.Text;
                TextBox DescnIT = (TextBox)row.Cells[0].FindControl("DescripcionIT");
                detalle.DescripcionIT = DescnIT.Text;
                Label numerodia = (Label)row.Cells[0].FindControl("txtNDia");
                detalle.NumDia = Convert.ToInt32(numerodia.Text);
                int idDet;
                Label IdDet = (Label)row.Cells[0].FindControl("txtIdDet");
                idDet = Convert.ToInt32(IdDet.Text);
                if (idDet > 0)
                {
                    detalle.Id = idDet;

                }
                int IdServ = Convert.ToInt32(Session["ID"]);
                if (IdServ > 0)
                {
                    detalle.IdServicio = IdServ;

                }
                detail.Add(detalle);
            }
            return detail;

        }
       

        //upload image boton
        protected void LoadPicture_Click(object sender, EventArgs e)
        {
            //1- agrega la imagen a la BD
            //2-La muestra
            if (FileUpload1.HasFile)
            {
                ErrorMSG.Visible = false;
                ErrorMSG.Text = "";
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] image = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    int imageId = ImagenesDAL.newImagen(FileUpload1.FileName, image);
                    IDImage.Text = "";//imageId
                    IDImage.Visible = false;
                    Image2.Visible = true;
                    string a = "data:image/jpg;base64," + Convert.ToBase64String(image); 
                    Image2.ImageUrl = a;
                    BtnDelImg.Visible = true;
                    FileUpload1.Visible = false;
                    BtnAddImg.Visible = false;
                    //FileUpload = FileUpload1;
                    //GetImage(image);
                    IDImage.Text =imageId.ToString();

                }

            }
            else
            {
                ErrorMSG.Visible = true;
                ErrorMSG.Text = "Selecciones una imagen";
                ErrorMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void DelPicture_Click(object sender, EventArgs e)
        {
            IDImage.Text = "";
            IDImage.Visible = false;
            Image2.ImageUrl = "";
            FileUpload1.Visible = true;
            BtnAddImg.Visible = true;
            BtnDelImg.Visible = false;
            ErrorMSG.Text = "";
            ErrorMSG.Visible = false;
        }


        private void LoadPicture(byte[] image, int imageId)
        {

            IDImage.Text = "";//imageId
            IDImage.Visible = false;
            Image2.Visible = true;
            string a = "data:image/jpg;base64," + Convert.ToBase64String(image); ;
            Image2.ImageUrl = a;
            BtnDelImg.Visible = true;
            FileUpload1.Visible = false;
            BtnAddImg.Visible = false;
            IDImage.Text = imageId.ToString();
        }
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;
            BindData();
            var DataSource = (IList<ModelClasses.Servicio>)Grid.DataSource;
            switch (sortExpression)
            {
                case "Nombre":
                    DataSource = (from c in DataSource
                                  orderby c.Nombre ascending
                                  select c).ToList();
                    break;
                case "Actividad":
                    DataSource = (from c in DataSource
                                  orderby c.Actividad ascending
                                  select c).ToList();
                    break;
                case "NombreOperador":
                    DataSource = (from c in DataSource
                                  orderby c.NombreOperador ascending
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