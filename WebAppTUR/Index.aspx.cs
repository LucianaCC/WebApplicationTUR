using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string OUT = Request.QueryString["Out"];
            if (!String.IsNullOrEmpty(OUT))
            {
                Session["User"] = string.Empty;
                Response.Redirect("~/index.aspx");
            }
            else { }

        }
    }


    protected void Authenticate(object sender, AuthenticateEventArgs e)
    {
        string password = login_.Password;
        string email = login_.UserName;

        //bool Validated = AccountDAL.verifyAccount(password, email);
        if (password == "luc1234" && email == "luciana.cavalieri")
        {
            login_.Visible = true;
            Session["User"] = "Luciana Cavalieri";//AccountDAL.getUser(password, email);
            Response.Redirect("~/Inicio.aspx");

        }
        else
        {
            // Response.Write("Invalid Login");
        }

    }
}