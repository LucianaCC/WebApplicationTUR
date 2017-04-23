<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Programas.aspx.cs" Inherits="WebAppTUR.Programas.Programas" %>
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
        
          <asp:Table ID="Table2" runat="server">  


              <asp:TableRow>
              <asp:TableCell> <asp:Label ID="lblTituloEs" runat="server" Text="Titulo:"> </asp:Label> </asp:TableCell>
           <asp:TableCell>   <div class="col-lg-4">
            
            <div class="bs-component" style="width:350px">
              <ul class="nav nav-tabs">
                <li class="active"><a href="#ES" data-toggle="tab" aria-expanded="true">Español</a></li>
                <li class=""><a href="#EN" data-toggle="tab" aria-expanded="false">Ingles</a></li>
                 <li class=""><a href="#PT" data-toggle="tab" aria-expanded="false">Protugues</a></li>
                <li class=""><a href="#IT" data-toggle="tab" aria-expanded="false">Ingles</a></li>
              </ul>
                <br />
              <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade active in" id="ES">
                
             <asp:TextBox ID="txtTituloEs" runat="server" Width="200" > </asp:TextBox>
                </div>

                <div class="tab-pane fade" id="EN">
                <asp:TextBox ID="txtTituloEN" runat="server" Width="200" > </asp:TextBox>      
                </div>

                    <div class="tab-pane fade" id="PT">
               <asp:TextBox ID="txtTituloPT" runat="server" Width="200"  > </asp:TextBox>      
                </div>

                    <div class="tab-pane fade" id="IT">
               <asp:TextBox ID="txtTituloIT" runat="server" Width="200" > </asp:TextBox>      
                </div>
                
                
              </div>
            </div>
          </div>      </asp:TableCell> </asp:TableRow>
          </asp:Table>
         
             <br />
            
         <asp:Table ID="Table1" runat="server">        
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
         <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Cant. Dias:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:TextBox ID="txtCantDias" runat="server" > </asp:TextBox></asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Idioma:"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:DropDownList ID="ddlIdioma" runat="server"  AppendDataBoundItems="true" AutoPostBack="true"   > 
       </asp:DropDownList></asp:TableCell>   
         </asp:TableRow>
             <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label8" runat="server" Text="Región:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:TextBox ID="txtRegion" runat="server" > </asp:TextBox></asp:TableCell> 
         </asp:TableRow>
         
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Dolar:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:TextBox ID="txtDolar" runat="server" > </asp:TextBox></asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Euro:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:TextBox ID="txtEuro" runat="server" > </asp:TextBox></asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Margen:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:TextBox ID="txtMargen" runat="server" > </asp:TextBox></asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label6" runat="server" Text="Descuento:"> </asp:Label></asp:TableCell> 
             <asp:TableCell><asp:TextBox ID="txtDescuento" runat="server" > </asp:TextBox></asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label7" runat="server" Text="Fecha Validez:"> </asp:Label>             
          </asp:TableCell><asp:TableCell> <asp:TextBox CssClass="form-control" ID="txtFechaVal" runat="server"></asp:TextBox>
          <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaVal" Format="M/d/yyyy">
          </asp:CalendarExtender></asp:TableCell>  
        
         </asp:TableRow>

          </asp:Table>
         <br />
        <div style="background-color: aliceblue;">
        <span style="font-style:italic;">
         Aereos
         </span>
     <asp:GridView ID="GridAereos"  runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>Fecha</HeaderTemplate>
        <ItemTemplate>
           <asp:TextBox CssClass="form-control" ID="Fhasta" runat="server" Width="85px"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Fhasta" Format="M/d/yyyy"></asp:CalendarExtender>
        </ItemTemplate>
    </asp:TemplateField> 
         <asp:TemplateField>
        <HeaderTemplate>Aereo</HeaderTemplate>
        <ItemTemplate>
            <asp:DropDownList runat="server" ID="ddlAereos"  AppendDataBoundItems="true" AutoPostBack="false"  Width="190px" ></asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField> 
        <asp:TemplateField>
        <HeaderTemplate>Cant.Pasajeros</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCantPasaj" Width="60px"  ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Unitario</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostUnit" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Total</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostTot" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
             
        <asp:CommandField ShowEditButton="True" />
          <asp:TemplateField HeaderText="Delete">
<ItemTemplate>
<asp:Button ID="deleteButtonAereo" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?');" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nuevo">
<ItemTemplate>
<asp:Button ID="AgregarButtonAereo" runat="server" CommandName="Add" Text="Agregar"  />
</ItemTemplate>
</asp:TemplateField>
       
               
       
    </Columns>
</asp:GridView>
        </div>
         <br />
        <div style="background-color: aliceblue;">
        <span style="font-style:italic;">
         Transfer
         </span>
           <asp:GridView ID="GridTransfer"  runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>Fecha</HeaderTemplate>
        <ItemTemplate>
           <asp:TextBox CssClass="form-control" ID="Fhasta" runat="server" Width="85px"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Fhasta" Format="M/d/yyyy"></asp:CalendarExtender>
        </ItemTemplate>
    </asp:TemplateField> 
         <asp:TemplateField>
        <HeaderTemplate>Transfer</HeaderTemplate>
        <ItemTemplate>
            <asp:DropDownList runat="server" ID="ddlTransfer"  AppendDataBoundItems="true" AutoPostBack="false"  Width="190px" ></asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField> 
        <asp:TemplateField>
        <HeaderTemplate>Cant.Pasajeros</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCantPasaj" Width="60px"  ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Unitario</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostUnit" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Total</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostTot" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>               
       
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField HeaderText="Nuevo">
<ItemTemplate>
<asp:Button ID="deleteButtonTransfer" runat="server" CommandName="Add" Text="Agregar"  />
</ItemTemplate>
</asp:TemplateField>
           <asp:TemplateField HeaderText="Delete">
<ItemTemplate>
<asp:Button ID="AgregarButtonTransfer" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?');" />
</ItemTemplate>
</asp:TemplateField>
             
       
    </Columns>
</asp:GridView>
        </div>
         <br />
        <div style="background-color: aliceblue;">
        <span style="font-style:italic;">
         Servicios
         </span>
           <asp:GridView ID="GridServicio"  runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>Fecha</HeaderTemplate>
        <ItemTemplate>
           <asp:TextBox CssClass="form-control" ID="Fhasta" runat="server" Width="85px"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Fhasta" Format="M/d/yyyy"></asp:CalendarExtender>
        </ItemTemplate>
    </asp:TemplateField> 
         <asp:TemplateField>
        <HeaderTemplate>Servicios</HeaderTemplate>
        <ItemTemplate>
            <asp:DropDownList runat="server" ID="ddlServicio"  AppendDataBoundItems="true" AutoPostBack="false"  Width="190px" ></asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField> 
        <asp:TemplateField>
        <HeaderTemplate>Cant.Pasajeros</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCantPasaj" Width="60px"  ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Unitario</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostUnit" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Total</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostTot" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
               
       
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField HeaderText="Nuevo">
<ItemTemplate>
<asp:Button ID="deleteButtonServicios" runat="server" CommandName="Add" Text="Agregar"  />
</ItemTemplate>
</asp:TemplateField>
             <asp:TemplateField HeaderText="Delete">
<ItemTemplate>
<asp:Button ID="AgregarButtonServicios" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?');" />
</ItemTemplate>
</asp:TemplateField>
           
       
    </Columns>
</asp:GridView>
        </div>
         <br />
        <div style="background-color: aliceblue;">
        <span style="font-style:italic;">
         Hoteles
         </span>
           <asp:GridView ID="GridHoteles"  runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>Fecha</HeaderTemplate>
        <ItemTemplate>
           <asp:TextBox CssClass="form-control" ID="Fhasta" runat="server" Width="85px"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Fhasta" Format="M/d/yyyy"></asp:CalendarExtender>
        </ItemTemplate>
    </asp:TemplateField> 
         <asp:TemplateField>
        <HeaderTemplate>Hoteles</HeaderTemplate>
        <ItemTemplate>
            <asp:DropDownList runat="server" ID="ddlHotel"  AppendDataBoundItems="true" AutoPostBack="false"  Width="190px" ></asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField> 
        <asp:TemplateField>
        <HeaderTemplate>Cant.Pasajeros</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCantPasaj" Width="60px"  ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Unitario</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostUnit" Width="60px" ></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <HeaderTemplate>Costo Total</HeaderTemplate>
        <ItemTemplate>
            <asp:TextBox runat="server" ID="txtCostTot" Width="60px" ></asp:TextBox>
        </ItemTemplate>

    </asp:TemplateField>
               
       
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField HeaderText="Nuevo">
<ItemTemplate>
<asp:Button ID="deleteButtonHoteles" runat="server" CommandName="Add" Text="Agregar"  />
</ItemTemplate>
</asp:TemplateField>
          <asp:TemplateField HeaderText="Delete">
<ItemTemplate>
<asp:Button ID="AgregarButtonHoteles" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?');" />
</ItemTemplate>
</asp:TemplateField>
              
       
    </Columns>
</asp:GridView>
        </div>


       <h3><asp:Button ID="BTNSavenew" runat="server"  CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveNew_Click" /> 
      <asp:Button ID="BTNSaveUpdat" runat="server"   CssClass="btn btn-primary btn-large"     Text="Guardar" onclick="SaveUpdat_Click" />
      <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-large"    onclick="Cancel_Click" Text="Cancelar" /></h3>
         <br />
         <br />
         <br />
  </asp:View>
     <asp:View ID="View2" runat="server">
     <h2><span><asp:Button ID="Button1" runat="server" 
       CssClass="btn btn-primary btn-large" 
      Text="Nuevo Programa" onclick="New_Click" /></span></h2> 
      <br />
      <div class="pagination-centered center-block"  >
 <asp:DataGrid ID="Grid" DataKeyField="Id" runat="server" PageSize="20" AllowPaging="True" OnSortCommand="Grid_SortCommand" 
AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand" AllowSorting="True"  >
<Columns>

<asp:BoundColumn HeaderText="Región" DataField="Nombre" SortExpression="Nombre"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Paquete" DataField="Pais"  SortExpression="Pais"></asp:BoundColumn>
<asp:BoundColumn DataField="Categoria" HeaderText="Categoria"  SortExpression="Codigo"></asp:BoundColumn>
<asp:BoundColumn DataField="Categoria" HeaderText="Fecha IN"  SortExpression="Codigo"></asp:BoundColumn>
<asp:BoundColumn DataField="Categoria" HeaderText="Fecha OUT"  SortExpression="Codigo"></asp:BoundColumn>
<asp:BoundColumn DataField="Categoria" HeaderText="Idioma"  SortExpression="Codigo"></asp:BoundColumn>
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
    </div>
     </asp:View>
 </asp:MultiView>
   
 <link href="../Bootstramp/bootstrap.min.css" rel="stylesheet"/>
 <link href="../Bootstramp/bootstrap.css" rel="stylesheet"/>
 <script src="../Bootstramp/Jquery.js" type="text/javascript"></script>
 <script src="../Bootstramp/bootstrap.min.js" type ="text/javascript"></script>
 <div class="pagination-centered" >
 </div>
</div>
  
</ContentTemplate>
</asp:UpdatePanel>
 </div> 
</asp:Content>
