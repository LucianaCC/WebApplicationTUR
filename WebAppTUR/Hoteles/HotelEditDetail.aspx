<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="HotelEditDetail.aspx.cs" Inherits="WebAppTUR.Hoteles.HotelEditDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
         
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate>   
<div class="offset3 span6"> 
<h2><span>Hoteles</span></h2>
     <asp:Table ID="Table3" runat="server">
       <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Nombre"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTnombre" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Ciudad"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="DdlCiudad" runat="server"> </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Categoria"> </asp:Label></asp:TableCell> 
         <asp:TableCell> <asp:DropDownList ID="DdLCategorias" runat="server"> </asp:DropDownList></asp:TableCell> 
         </asp:TableRow>
         
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Direccion"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control"  ID="TXTDireccion" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Telefono"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control"  ID="TXTTelefono" runat="server"></asp:TextBox></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label6" runat="server" Text="Contacto"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control"  ID="TXTContacto" runat="server"></asp:TextBox></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label7" runat="server" Text="Email"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTEmail" runat="server"></asp:TextBox></asp:TableCell> 
         </asp:TableRow>

         <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label13" runat="server" Text="Check In"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:DropDownList   ID="DdpCHIN" runat="server"></asp:DropDownList>
        <asp:DropDownList   ID="DdpCHINMin" runat="server"></asp:DropDownList></asp:TableCell> 
        </asp:TableRow>

         <asp:TableRow>
        <asp:TableCell><asp:Label  ID="Label14" runat="server" Text="Check Out"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:DropDownList   ID="DdpCHout" runat="server"></asp:DropDownList>
        <asp:DropDownList   ID="DdpCHoutMin" runat="server"></asp:DropDownList></asp:TableCell> 
        </asp:TableRow>

         <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label15" runat="server" Text="Observaciones"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:TextBox  Width="350" Height="180" ID="TXTObsHotel" runat="server" TextMode="MultiLine" ></asp:TextBox></asp:TableCell> 
        </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell>  <h3> <span>Detalle Banco</span></h3></asp:TableCell> 
         </asp:TableRow>  
             
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label8" runat="server" Text="Nombre"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="TXTBcoNombre" CssClass="form-control"  runat="server"></asp:TextBox></asp:TableCell> 
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label9" runat="server" Text="Numero de cuenta"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="TXTCta" CssClass="form-control"  runat="server"></asp:TextBox></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label10" runat="server" Text="CUIT"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="TXTCuit" CssClass="form-control"  runat="server"></asp:TextBox></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label11" runat="server" Text="CBU"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="TXTCBU" CssClass="form-control"  runat="server"></asp:TextBox></asp:TableCell> 
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label12" runat="server" Text="Observacion Bco"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="TXTObs"  Width="350" Height="180" runat="server" TextMode="MultiLine"></asp:TextBox></asp:TableCell> 
         </asp:TableRow>       
         
        </asp:Table> 

<h3><span> <asp:Button ID="BTNSavenew" runat="server" CssClass="btn btn-primary btn-large"  Text="Guardar" onclick="SaveNew_Click" /> 
<asp:Button ID="BTNSaveUpdat" runat="server" CssClass="btn btn-primary btn-large" Text="Cancelar" onclick="Cancel_Click" /></span></h3> 

  <link href="../Bootstramp/bootstrap.min.css" rel="stylesheet"/>
  <link href="../Bootstramp/bootstrap.css" rel="stylesheet"/>
  <script src="../Bootstramp/Jquery.js" type="text/javascript"></script>
  <script src="../Bootstramp/bootstrap.min.js" type ="text/javascript"></script>
     
</div> 
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

