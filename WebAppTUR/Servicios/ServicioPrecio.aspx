<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ServicioPrecio.aspx.cs" Inherits="WebAppTUR.Servicios.ServicioPrecio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="offset3 span6">
 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager> 

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
   <asp:View ID="View1" runat="server">
        <h2><span>Precio de los Servicios</span></h2>
                    
         <asp:Table ID="Table1" runat="server">        
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="lblNombreEdit" runat="server" Text="Nombre:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:Label ID="NombreEditando" runat="server" Text=""> </asp:Label></asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Ciudad"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlCiudad" runat="server"  AppendDataBoundItems="true" AutoPostBack="true"  OnTextChanged="Ciudad_OnSelectedIndexChanged" OnSelectedIndexChanged="Ciudad_OnSelectedIndexChanged" > 
       </asp:DropDownList> <asp:Label ID="labelCiudad" runat="server" > </asp:Label></asp:TableCell>   
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label19" runat="server" Text="Operador"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlOperador" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="Operador_OnSelectedIndexChanged" OnTextChanged="Operador_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><asp:Label ID="LabelOperador" runat="server" ></asp:Label> </asp:TableCell>   
         </asp:TableRow>

          <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label13" runat="server" Text="Fecha Desde:"> </asp:Label>             
          </asp:TableCell><asp:TableCell> <asp:TextBox CssClass="form-control" ID="Fdesde" runat="server"></asp:TextBox>
          <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Fdesde" Format="M/d/yyyy">
          </asp:CalendarExtender></asp:TableCell>  
        
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label14" runat="server" Text="Fecha Hasta:"> </asp:Label> </asp:TableCell>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="Fhasta" runat="server"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Fhasta" Format="M/d/yyyy">
         </asp:CalendarExtender></asp:TableCell>         
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label15" runat="server" Text="Moneda"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlMoneda" runat="server" AppendDataBoundItems="true" > </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:Label ID="lblPrecio" runat="server" Text="Precio"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="TXTPrecioEdit" runat="server" > </asp:TextBox></asp:TableCell>   
         </asp:TableRow>
             <asp:TableRow>
         <asp:TableCell><asp:Label ID="lblsvs" runat="server" Text="SVS"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="txtSVS" runat="server" > </asp:TextBox></asp:TableCell>   
         </asp:TableRow>
        </asp:Table>
         <asp:Table ID="Tabla4" runat="server">
         <asp:TableRow>
         <asp:TableCell Width="400" ><asp:Label ID="TXTError" runat="server" Text=""> </asp:Label></asp:TableCell> 
         </asp:TableRow>
         </asp:Table>
         <br /> 
       
          <asp:GridView ID="GridPreciosLista"  runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>Servicio</HeaderTemplate>
        <ItemTemplate>
            <asp:Label runat="server" ID="txtNombre" Text='<%# Bind("Nombre") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>   
    <asp:TemplateField>
        <HeaderTemplate>Tipo 1 <asp:TextBox  BackColor="Green" runat="server" ID="txtTipo1" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio1" Width="50px" ></asp:TextBox>
            <asp:Button id="btn1" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 2 <asp:TextBox BackColor="Green" runat="server" ID="txtTipo2" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio2" Width="50px" ></asp:TextBox>
             <asp:Button id="btn2" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 3 <asp:TextBox BackColor="Purple" runat="server" ID="txtTipo3" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio3" Width="50px" ></asp:TextBox>
           <asp:Button id="btn3" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 4 <asp:TextBox BackColor="Purple" runat="server" ID="txtTipo4" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio4" Width="50px" ></asp:TextBox>
             <asp:Button id="btn4" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 5 <asp:TextBox  BackColor="Purple" runat="server" ID="txtTipo5" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio5" Width="50px" ></asp:TextBox>
            <asp:Button id="btn5" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 6 <asp:TextBox  BackColor="Purple" runat="server" ID="txtTipo6" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio6" Width="50px" ></asp:TextBox>
            <asp:Button id="btn6" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 7 <asp:TextBox  BackColor="Purple" runat="server" ID="txtTipo7" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio7" Width="50px" ></asp:TextBox>
             <asp:Button id="btn7" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 8 <asp:TextBox  BackColor="Purple" runat="server" ID="txtTipo8" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server"  ID="txtTipoPrecio8" Width="50px" ></asp:TextBox>
             <asp:Button id="btn8" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 9 <asp:TextBox  BackColor="Purple" runat="server" ID="txtTipo9" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server"  ID="txtTipoPrecio9" Width="50px" ></asp:TextBox>
           <asp:Button id="btn9" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Tipo 10 <asp:TextBox  BackColor="Purple" runat="server" ID="txtTipo10" Width="50px"  ></asp:TextBox></HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtTipoPrecio10" Width="50px" ></asp:TextBox>
            <asp:Button id="btn10" OnClick="UnitGroup_Click"  runat ="server"  Text="Unit" />
        </ItemTemplate>
    </asp:TemplateField>
       
    </Columns>
</asp:GridView>


       <h3><asp:Button ID="BTNSavenew" runat="server"  CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveNew_Click" /> 
      <asp:Button ID="BTNSaveUpdat" runat="server"   CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveUpdat_Click" />
      <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-large"    onclick="Cancel_Click" Text="Cancelar" /></h3>
         <br />
         <br />
         <br />
  </asp:View>

   <asp:View ID="View2" runat="server">
   <h3><span> Precio Servicios</span></h3>

      <h3><span> <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-large" 
           onclick="New_Click" Text="Nuevo Servicio Precio" /></span></h3> 
       
       
<asp:DataGrid ID="Grid" DataKeyField="Id" DataKeyName="Id" runat="server" PageSize="20" AllowPaging="True" 
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand"  OnSortCommand="Grid_SortCommand"  AllowSorting="True"  >
<Columns>
<asp:BoundColumn HeaderText="Ciudad" DataField="CiudadServicio" SortExpression="CiudadServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Operador" DataField="OperadorServicio" SortExpression="OperadorServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Actividad" DataField="ActividadServicio" SortExpression="ActividadServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Nombre" DataField="NombreServicio" SortExpression="NombreServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="SVS" DataField="TipoServicio" SortExpression="TipoServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="F.Desde" DataField="FdesdeServicio" SortExpression="FdesdeServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="F.Hasta" DataField="FHastaServicio" SortExpression="FHastaServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Precio" DataField="Precio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Moneda" DataField="MonedaServicio"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Unit/Grup" DataField="UnitarioGrupal"></asp:BoundColumn>

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
