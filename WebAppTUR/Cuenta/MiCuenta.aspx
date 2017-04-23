<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="WebAppTUR.Cuenta.MiCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


    <div  >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="offset3 span6">
    <h2>Mi cuenta</h2>
         <asp:DataGrid ID="Grid" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyField="Id" ForeColor="#333333" GridLines="None" OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnPageIndexChanged="Grid_PageIndexChanged" OnUpdateCommand="Grid_UpdateCommand" PageSize="20">
             <Columns>
                 <asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
                 <asp:BoundColumn DataField="Pais" HeaderText="Pais"></asp:BoundColumn>
                 <asp:BoundColumn DataField="Codigo" HeaderText="Codigo"></asp:BoundColumn>
                 <asp:EditCommandColumn CancelText="Cancel" EditText="Edit" HeaderText="Edit" UpdateText="Update"></asp:EditCommandColumn>
                 <asp:TemplateColumn HeaderText="Delete">
                     <ItemTemplate>
                         <asp:Button ID="deleteButton" runat="server" CommandName="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?');" Text="Delete" />
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


