<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Operador.aspx.cs" Inherits="WebAppTUR.Operadores.Operador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


<div >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="offset3 span6">
   

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
     <asp:View ID="View1" runat="server">
        <h2><span>Operadores</span></h2>
                    
         <asp:Table ID="Table1" runat="server">
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Nombre Operador"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTnombre" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Ciudad"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlCiudad" runat="server"> </asp:DropDownList></asp:TableCell>   
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
         <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Codigo Postal"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTCodPost" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label16" runat="server" Text="Fax"> </asp:Label></asp:TableCell> 
       <asp:TableCell><asp:TextBox CssClass="form-control"  ID="TXTFax" runat="server"></asp:TextBox></asp:TableCell> 
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
        <asp:TableCell><asp:Label ID="Label12" runat="server" Text="Dirección Bco"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:TextBox ID="TXTDireccionBco" CssClass="form-control" runat="server" ></asp:TextBox></asp:TableCell> 
        </asp:TableRow>
         <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label10" runat="server" Text="CUIT"> </asp:Label></asp:TableCell> 
       <asp:TableCell><asp:TextBox ID="TXTCuit" CssClass="form-control"  runat="server"></asp:TextBox></asp:TableCell> 
  
         </asp:TableRow>
         <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label11" runat="server" Text="CBU"> </asp:Label></asp:TableCell> 
       <asp:TableCell><asp:TextBox ID="TXTCBU" CssClass="form-control"  runat="server"></asp:TextBox></asp:TableCell> 
        </asp:TableRow>
            
        
         
        </asp:Table> 
       <h3><asp:Button ID="BTNSavenew" runat="server"  CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveNew_Click" /> 
      <asp:Button ID="BTNSaveUpdat" runat="server"   CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveUpdat_Click" />
      <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-large"    onclick="Cancel_Click" Text="Cancelar" /></h3>
         <br />
         <br />
         <br />
  </asp:View>

   <asp:View ID="View2" runat="server">
   <h3><span> Operadores</span></h3>

      <h3><span> <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-large" 
           onclick="New_Click" Text="Nuevo Operador" /></span></h3> 
       
       
<asp:DataGrid ID="Grid" DataKeyField="Id" runat="server" PageSize="20" AllowPaging="True" 
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand"  OnSortCommand="Grid_SortCommand"  AllowSorting="True" >
<Columns>

<asp:BoundColumn HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Ciudad" DataField="CiudadNombre" SortExpression="CiudadNombre"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Pais" DataField="Pais" SortExpression="Pais"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Email" DataField="Email" ></asp:BoundColumn>
<asp:BoundColumn HeaderText="Contacto" DataField="Contacto"></asp:BoundColumn>

<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit">
</asp:EditCommandColumn>
<asp:TemplateColumn HeaderText="Delete">
<ItemTemplate>
<asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?');" />
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<EditItemStyle BackColor="#2461BF" />
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
<SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
<AlternatingItemStyle BackColor="White" />
<ItemStyle BackColor="#EFF3FB" />
<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
</asp:DataGrid>    
   
   </asp:View>

</asp:MultiView>
 <link href="../Bootstramp/bootstrap.min.css" rel="stylesheet"/>

  <link href="../Bootstramp/bootstrap.css" rel="stylesheet"/>
<%--<link href="../Styles/StyleSheet.css" rel="stylesheet"/>--%>
  <script src="../Bootstramp/Jquery.js" type="text/javascript"></script>
  <script src="../Bootstramp/bootstrap.min.js" type ="text/javascript"></script>
      <div class="pagination-centered" >
    </div>
</div>
  
</ContentTemplate>
</asp:UpdatePanel>
    </div>    

</asp:Content>


