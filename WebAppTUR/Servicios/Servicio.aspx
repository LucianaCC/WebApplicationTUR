<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="WebAppTUR.Servicios.Servicio"%>
<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager id="ToolkitScriptManager2" runat="server">
 
    </cc1:ToolkitScriptManager>
   
<ContentTemplate>
<div class="offset3 span6">
   

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
         <asp:View ID="View1" runat="server">
<div>
         <h2><span>Nuevo Servicio</span></h2>
                    
         <asp:Table ID="Table1" runat="server">
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Nombre"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox  CssClass="form-control" ID="TXTnombre" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label21" runat="server" Text="Actividad"> </asp:Label></asp:TableCell> 
         <asp:TableCell>
         <asp:DropDownList ID="ddlActividad"  AutoPostBack="true" runat="server" OnTextChanged="Actividad__OnSelectedIndexChanged" OnSelectedIndexChanged="Actividad__OnSelectedIndexChanged"> </asp:DropDownList>

         </asp:TableCell>   
         </asp:TableRow>
              <asp:TableRow>
         <asp:TableCell><asp:Label ID="LabelTransfer" runat="server" Text="Tipo Transfer"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlTipoTransfer" runat="server"> </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>

         
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label20" runat="server" Text="Cantidad de Dias" > </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:TextBox ID="txtDias" runat="server" CssClass="form-control"></asp:TextBox> &nbsp;&nbsp;&nbsp;
               <asp:Button ID="btnGenerarTabla" runat="server" CssClass="btn btn-primary btn-large"    onclick="GenerarTabla" Text="Crear detalle Idiomas" /></h3>        
        <cc1:NumericUpDownExtender   ID="NumericUpDownExtender1"  runat="server"  Width="80"   TargetControlID="txtDias"  Minimum="0"  Maximum="90">  
        </cc1:NumericUpDownExtender>  
             </asp:TableCell>
         </asp:TableRow>    
         

        
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label23" runat="server" Text="Ciudad de Operador"> </asp:Label></asp:TableCell> 
          <asp:TableCell>
          <asp:DropDownList ID="ddlCiudad" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Ciudad_OnSelectedIndexChanged" OnTextChanged="Ciudad_OnSelectedIndexChanged" >
   </asp:DropDownList>             
          </asp:TableCell> 
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label24" runat="server" Text="Operador"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlOperador" runat="server"> </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Ciudad Origen"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlCiudadOrigen" runat="server"> </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label19" runat="server" Text="Ciudad Destino"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlCiudadDestino" runat="server"> </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>

         <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label13" runat="server" Text="Hora Origen"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:DropDownList   ID="DdlHOrigen" runat="server"></asp:DropDownList>
        <asp:DropDownList   ID="DdlMinOrigen" runat="server"></asp:DropDownList></asp:TableCell> 
        </asp:TableRow>

         <asp:TableRow>
        <asp:TableCell><asp:Label  ID="Label14" runat="server" Text="Hora Destino"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:DropDownList   ID="DdlHDestino" runat="server"></asp:DropDownList>
        <asp:DropDownList   ID="DdlMinDestino" runat="server"></asp:DropDownList></asp:TableCell> 
        </asp:TableRow>   
      <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label15" runat="server" Text="Observaciones"> </asp:Label></asp:TableCell> 
        <asp:TableCell><asp:TextBox  Width="350" Height="180" ID="TXTObs" runat="server" TextMode="MultiLine" ></asp:TextBox></asp:TableCell> 
        </asp:TableRow>
        
        <asp:TableRow>
        <asp:TableCell>  <h3> <span>Detalle Servicio</span></h3></asp:TableCell> 
        </asp:TableRow>         
        </asp:Table>      
        <br />
       <asp:GridView ID="GridDetalleLista"  runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
          <Columns>
    <asp:TemplateField>
        <HeaderTemplate>Nº de dia</HeaderTemplate>
        <ItemTemplate>
            <asp:Label runat="server" Width="25px"  ID="txtNDia" Text='<%# Bind("NumDia") %>'></asp:Label>
            <asp:Label runat="server" Width="25px"  Visible="false" ID="txtIdDet" Text='<%# Bind("Id") %>'></asp:Label>
            <%-- <asp:Button runat="server" Width="50px" ID="IDBTNDelate" Text="Borrar" Diaonclick="DeleteDetalle_Click"   ></asp:Button>--%>
        </ItemTemplate>
    </asp:TemplateField>   
    <asp:TemplateField>
        <HeaderTemplate>Detalle Es </HeaderTemplate>
        <ItemTemplate>
            <h4>Titulo: </h4> <asp:TextBox runat="server" Width="280px" ID="NombreES" Text='<%# Bind("NombreES") %>'></asp:TextBox>
           <br />
           <h4>Descripcion: </h4> <asp:TextBox Width="305px" Height="210px" runat="server" TextMode="MultiLine" ID="DescripcionEs" Text='<%# Bind("DescripcionEs") %>'></asp:TextBox>
          
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Detalle PT </HeaderTemplate>
        <ItemTemplate>
            
             <h4>Titulo: </h4> <asp:TextBox runat="server"  Width="280px" ID="NombrePT" Text='<%# Bind("NombrePT") %>'></asp:TextBox>            
            <br />
          <h4>Descripcion: </h4> <asp:TextBox Width="305px" Height="210px" TextMode="MultiLine" runat="server" ID="DescripcionPT" Text='<%# Bind("DescripcionPT") %>'></asp:TextBox>
          
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Detalle EN </HeaderTemplate>
        <ItemTemplate>
         
             <h4>Titulo: </h4> <asp:TextBox runat="server"  Width="280px" ID="NombreEN" Text='<%# Bind("NombreEN") %>'></asp:TextBox>            
            <br />
          <h4>Descripcion: </h4> <asp:TextBox Width="305px" Height="210px" TextMode="MultiLine" runat="server" ID="DescripcionEN" Text='<%# Bind("DescripcionEN") %>'></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
         <asp:TemplateField>
        <HeaderTemplate>Detalle IT </HeaderTemplate>
        <ItemTemplate>           
             <h4>Titulo: </h4> <asp:TextBox runat="server"  Width="280px" ID="NombreIT" Text='<%# Bind("NombreIT") %>'></asp:TextBox>            
            <br />
          <h4>Descripcion: </h4> <asp:TextBox Width="305px" Height="210px" TextMode="MultiLine" runat="server" ID="DescripcionIT" Text='<%# Bind("DescripcionIT") %>'></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField> 
    </Columns>
</asp:GridView><br />

          <%--<asp:Image ID="Image1" runat="server"  Width="116px" Height="75px" />--%>
       
<br />
<h4>Imagen del servicio: </h4>
<br />

<asp:FileUpload ID="FileUpload1" runat="server" />

<br />
<asp:Label runat="server" ID="IDImage" Visible="false"></asp:Label>
<asp:Label runat="server" ID="ErrorMSG" Visible="false"></asp:Label>
<asp:Button ID="BtnAddImg" runat="server" CssClass="btn btn-primary btn-large"  onclick="LoadPicture_Click" Text="Agregar imagen" />
 <asp:Image ID="Image2" runat="server" Width="150px" Height="90px"  /> 
         <br />
         <asp:Button ID="BtnDelImg" runat="server" CssClass="btn btn-primary btn-large" onclick="DelPicture_Click" Text="Eliminar imagen" />
<br />



<br />

       <h3><asp:Button ID="BTNSavenew" runat="server"  CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveNew_Click" /> 
      <asp:Button ID="BTNSaveUpdat" runat="server"   CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveUpdat_Click" />
      <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-large"    onclick="Cancel_Click" Text="Cancelar" /></h3>
         <br />
         <br />
 <br />
       
    </div>

         </asp:View>  

   <asp:View ID="View2" runat="server">
   <h3><span> Servicios</span></h3>

      <h3><span> <asp:Button ID="Buttona" runat="server" CssClass="btn btn-primary btn-large" 
           onclick="New_Click" Text="Nuevo Servicio" /></span></h3> 
       
       
<asp:DataGrid ID="Grid" DataKeyField="Id" runat="server" PageSize="20" AllowPaging="True" 
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand"  OnSortCommand="Grid_SortCommand"  AllowSorting="True" >
<Columns>
<%--<asp:TemplateColumn HeaderText="Image"> 
 <ItemTemplate> 
    <asp:Image runat="server"  Width="50px" ID="Image1" ImageUrl='<%# Bind("ImgUrl") %>'></asp:Image>
<asp:Image ID="Image1" runat="server" Width="150" Height="100" ImageUrl='<%#Eval("ImgUrl")%>'/> 
</ItemTemplate> 
 </asp:TemplateColumn> --%>
<asp:BoundColumn HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Actividad" DataField="Actividad" SortExpression="Actividad"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Operador" DataField="NombreOperador" SortExpression="NombreOperador"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad"></asp:BoundColumn>


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
<Triggers>

<asp:PostBackTrigger ControlID="BtnAddImg" />

</Triggers>
 <%--   <Triggers>

<asp:PostBackTrigger ControlID="BtnAddImg" />

</Triggers>--%>
</asp:UpdatePanel>
       

</asp:Content>