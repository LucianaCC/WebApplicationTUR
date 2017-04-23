using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;

namespace WebAppTUR.Divisas
{
    public partial class Divisas : System.Web.UI.Page
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

        //protected void SaveNew_Click(object sender, EventArgs e)
        //{
        //    if (TXTCodigo.Text != "" && TXTnombre.Text != "" && TXTCambio.Text != "")
        //    {
        //        Divisas divisa = new Divisas();

        //        divisa.Nombre = TXTnombre.Text;
        //        divisa.Codigo = TXTCodigo.Text;
        //        divisa.Cambio = TXTCambio.Text;
        //        divisa.Simbolo = TXTSimbolo.Text;

        //        DivisasDALcs.newDivisas(divisa);


        //    }
        //    //GridView1.DataBind();
        //    MultiView1.SetActiveView(View2);

        //}

        //protected void New_Click(object sender, EventArgs e)
        //{
        //    MultiView1.Visible = true;
        //    TXTnombre.Text = "";
        //    TXTCodigo.Text = "";
        //    TXTCambio.Text = "";
        //    TXTSimbolo.Text = "";
        //    MultiView1.SetActiveView(View1);
        //}
        //protected void Cancel_Click(object sender, EventArgs e)
        //{
        //    MultiView1.SetActiveView(View2);

        //}
        private void BindData()
        {
            List<Divisa> ds = new List<Divisa>();
            ds = DivisasDAL.getAllDivisas();
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
            if (TXTCodigo.Text != "" && TXTnombre.Text != "" && TXTCambio.Text != "" && TXTSimbolo.Text != "")
            {
                Divisa nuevadivisa = new Divisa();
                nuevadivisa.Nombre = TXTnombre.Text.Trim();
                nuevadivisa.Codigo = TXTCodigo.Text.Trim();
                nuevadivisa.Simbolo = TXTSimbolo.Text.Trim();
                nuevadivisa.Cambio = Convert.ToDecimal(TXTCambio.Text);
                DivisasDAL.newDivisas(nuevadivisa);
                BindData();
            }

            MultiView1.SetActiveView(View2);

        }
        protected void New_Click(object sender, EventArgs e)
        {
            //MultiView1.Visible = true;
            TXTnombre.Text = string.Empty;
            TXTCodigo.Text = string.Empty;
            TXTCambio.Text = string.Empty;
            TXTSimbolo.Text = string.Empty;
            MultiView1.SetActiveView(View1);
            BindData();
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            BindData();

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
            Divisa updateDivida = new Divisa();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            updateDivida.Id = id;
            DivisasDAL.DeleteDivisa(updateDivida);
            BindData();
            MultiView1.SetActiveView(View2);
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

            Divisa updateDivisa = new Divisa();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            updateDivisa.Id = id;
            updateDivisa.Nombre = ((TextBox)e.Item.Cells[0].Controls[0]).Text.Trim();
            updateDivisa.Simbolo = ((TextBox)e.Item.Cells[1].Controls[0]).Text.Trim();
            updateDivisa.Codigo = ((TextBox)e.Item.Cells[2].Controls[0]).Text.Trim();
            updateDivisa.Cambio = Convert.ToDecimal(((TextBox)e.Item.Cells[3].Controls[0]).Text);
            DivisasDAL.EditDivisa(updateDivisa);
            Grid.EditItemIndex = -1;
            BindData();
            MultiView1.SetActiveView(View2);

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
    }
}