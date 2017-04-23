using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelClasses;
using DAL;


namespace WebAppTUR.Hoteles
{
    public partial class HotelABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["User"] != "")
                {
                    BindData();
                }
                else { Response.Redirect("~/index.aspx"); }

            }

        }
        private void BindData()
        {
            List<ModelClasses.Hotel> ds = new List<ModelClasses.Hotel>();
            ds = HotelesDAL.getAllHoteles();
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
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            Response.Redirect("~/Hoteles/HotelEditDetail.aspx?IDHotel=" + id.ToString());
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Desea eliminar" + "');", true);
            DAL.Hotel deletehotel = new DAL.Hotel();
            int id = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
            deletehotel.Id = id;
            HotelesDAL.DeleteHotel(deletehotel);
            BindData();

        }
        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        protected void New_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Hoteles/HotelEditDetail.aspx");
        }
        protected void Grid_SortCommand(object sender, DataGridSortCommandEventArgs e)
        {
            string sortExpression = e.SortExpression;
            BindData();
            var DataSource = (IList<ModelClasses.Hotel>)Grid.DataSource;
            switch (sortExpression)
            {
                case "Nombre":
                    DataSource = (from c in DataSource
                                  orderby c.Nombre ascending
                                  select c).ToList();
                    break;
                case "Categoria":
                    DataSource = (from c in DataSource
                                  orderby c.Categoria ascending
                                  select c).ToList();
                    break;
                case "Direcion":
                    DataSource = (from c in DataSource
                                  orderby c.Direcion ascending
                                  select c).ToList();
                    break;
                case "Telefono":
                    DataSource = (from c in DataSource
                                  orderby c.Telefono ascending
                                  select c).ToList();
                    break;
                case "NombreCiudad":
                    DataSource = (from c in DataSource
                                  orderby c.NombreCiudad ascending
                                  select c).ToList();
                    break;
            }
            Grid.DataSource = DataSource;
            Grid.DataBind();

        }

    }
}