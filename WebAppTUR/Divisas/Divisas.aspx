<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Divisas.aspx.cs" Inherits="WebAppTUR.Divisas.Divisas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


    <div  >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="offset3 span6">
   

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
     <asp:View ID="View1" runat="server">
      <h2><span>Nueva Divisa</span></h2>
        <asp:Table ID="Table1" runat="server">
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Nombre"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTnombre" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Codigo"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTCodigo" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Cambio"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTCambio" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Simbolo"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTSimbolo" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell> <asp:Button ID="Button2" runat="server"   CssClass="btn btn-primary btn-large"   Text="Guardar" onclick="SaveNew_Click" />
         </asp:TableCell> 
         <asp:TableCell><asp:Button ID="cancel" runat="server" CssClass="btn btn-primary btn-large" 
             onclick="Cancel_Click" Text="Cancelar" /></asp:TableCell>  
         </asp:TableRow>
         
         </asp:Table>  
     </asp:View>
     <asp:View ID="View2" runat="server">
     <h2><span><asp:Button ID="Button1" runat="server" 
       CssClass="btn btn-primary btn-large" 
      Text="Nueva Divisa" onclick="New_Click" /></span></h2> 
        
                   <asp:DataGrid ID="Grid" DataKeyField="Id" runat="server" PageSize="20" AllowPaging="True" 
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">
<Columns>

<asp:BoundColumn HeaderText="Nombre" DataField="Nombre"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Simbolo" DataField="Simbolo"></asp:BoundColumn>
<asp:BoundColumn DataField="Codigo" HeaderText="Codigo"></asp:BoundColumn>
<asp:BoundColumn DataField="Cambio" HeaderText="Cambio"></asp:BoundColumn>
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
      
      <br />
      <div class="pagination-centered center-block"  >
    </div>
     </asp:View>

</asp:MultiView>
 <link href="../Bootstramp/bootstrap.min.css" rel="stylesheet"/>
  <link href="../Bootstramp/bootstrap.css" rel="stylesheet"/>
  <script src="../Bootstramp/Jquery.js" type="text/javascript"></script>
  <script src="../Bootstramp/bootstrap.min.js" type ="text/javascript"></script>
  
</div>
  
</ContentTemplate>
</asp:UpdatePanel>
    </div>    

</asp:Content>
