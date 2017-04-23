<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="HotelABM.aspx.cs" Inherits="WebAppTUR.Hoteles.HotelABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="offset3 span6"> 
 <h3><span> Hoteles</span></h3>
<h3><span> <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-large" 
           onclick="New_Click" Text="Nuevo Hotel" /></span></h3> 
 <asp:DataGrid ID="Grid" DataKeyField="Id" runat="server" PageSize="20" AllowPaging="True" 
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" 
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand"  OnSortCommand="Grid_SortCommand"  AllowSorting="True" >
<Columns>
<asp:BoundColumn HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Categoria" DataField="Categoria" SortExpression="Categoria"></asp:BoundColumn>
<asp:BoundColumn DataField="Direcion" HeaderText="Direcion" SortExpression="Direcion"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Telefono" DataField="Telefono" SortExpression="Telefono"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Ciudad" DataField="NombreCiudad" SortExpression="NombreCiudad"></asp:BoundColumn>

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
 <link href="../Bootstramp/bootstrap.min.css" rel="stylesheet"/>
 <link href="../Bootstramp/bootstrap.css" rel="stylesheet"/>
 <script src="../Bootstramp/Jquery.js" type="text/javascript"></script>
 <script src="../Bootstramp/bootstrap.min.js" type ="text/javascript"></script>
</div>
  
</ContentTemplate>
</asp:UpdatePanel>
    </div>    

</asp:Content>


