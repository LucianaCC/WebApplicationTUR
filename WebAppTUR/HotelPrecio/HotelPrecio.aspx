<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="HotelPrecio.aspx.cs" Inherits="WebAppTUR.HotelPrecio.HotelPrecio" %>


<asp:Content ID="Content1" ContentPlaceHolderID="heads" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>


<div >         
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="offset3 span6">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager> 

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
     <asp:View ID="View1" runat="server">
        <h2><span>Nuevo Hotel Precio</span></h2>
                    
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="P1"
ErrorMessage="Please Enter Only Numbers" Style="z-index: 101; left: 424px; position: absolute;
top: 285px" ValidationExpression="^\d+$" ValidationGroup="check"></asp:RegularExpressionValidator>  --%>   
         <asp:Table ID="Table1" runat="server">
         <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label7" runat="server" Text="Ciudad: "> </asp:Label> </asp:TableCell> 
          <asp:TableCell>
          <asp:DropDownList ID="ddlCiudad" runat="server"  AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ciudad_OnSelectedIndexChanged" OnTextChanged="Ciudad_OnSelectedIndexChanged">
            <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
           </asp:DropDownList>              
          </asp:TableCell> 
         </asp:TableRow>
          <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Hotel: "> </asp:Label> </asp:TableCell> 
          <asp:TableCell>
          <asp:DropDownList ID="ddlHotel" runat="server"> </asp:DropDownList>              
          </asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Fecha Desde:"> </asp:Label>             
               </asp:TableCell><asp:TableCell> <asp:TextBox CssClass="form-control" ID="Fdesde" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Fdesde" Format="M/d/yyyy">
               </asp:CalendarExtender></asp:TableCell>  
        
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Fecha Hasta:"> </asp:Label> </asp:TableCell>
          <asp:TableCell><asp:TextBox CssClass="form-control" ID="Fhasta" runat="server"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Fhasta" Format="M/d/yyyy">
               </asp:CalendarExtender></asp:TableCell>         
         </asp:TableRow>
         
         
         </asp:Table>
         <asp:Table ID="Tabla4" runat="server">
         <asp:TableRow>
         <asp:TableCell Width="400" ><asp:Label ID="TXTError" runat="server" Text=""> </asp:Label></asp:TableCell> 
         </asp:TableRow>
         </asp:Table>
         <asp:Table ID="Table2" runat="server">
          <asp:TableRow>
         <asp:TableCell Width="400" ><asp:Label ID="Label2" runat="server" Text="Detalle de habitación"> </asp:Label></asp:TableCell> 
         
         <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Peso (00.00)"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:Label ID="Label6" runat="server" Text="Dolar (00.00)"> </asp:Label></asp:TableCell>  
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT1" runat="server" ></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P1" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D1" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT2" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P2" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D2" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT3" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P3" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D3" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT4" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P4" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D4" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT5" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P5" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D5" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT6" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P6" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D6" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT7" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P7" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D7" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT8" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P8" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D8" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT9" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P9" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D9" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXT10" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="P10" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="D10" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>

      
        </asp:Table> 
       <h3><asp:Button ID="BTNSavenew" runat="server" 
      CssClass="btn btn-primary btn-large" 
      Text="Guardar" onclick="SaveNew_Click" /> 
         
         <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-large" 
             onclick="cancel_Click" Text="Cancelar" Height="32px" /></h3>
         <br />
         <br />
         <br />
  </asp:View>

     <asp:View ID="View2" runat="server">
   <h3><span> Hoteles</span></h3>

      <h3><span> <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-large" 
           onclick="New_Click" Text="Nuevo Precio Hotel" /></span></h3> 
   
       <asp:DataGrid ID="Grid" DataKeyField="Id" runat="server" PageSize="20" AllowPaging="True" 
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" 
OnDeleteCommand="Grid_DeleteCommand"  EditItemStyle-Width="100" OnEditCommand="Grid_EditCommand"  OnSortCommand="Grid_SortCommand"  AllowSorting="True" >
<Columns>
<asp:BoundColumn HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Hotel" DataField="Name" SortExpression="Name"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Tipo Habitacion" DataField="NameHabitacion"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Fecha Desde" DataField="FDesdeString"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Fecha Hasta" DataField="FHastaString"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Precio Peso" DataField="PrecioPeso"></asp:BoundColumn>
<asp:BoundColumn HeaderText="Precio Dolar" DataField="PrecioDolar"></asp:BoundColumn>

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

   <asp:View ID="View3" runat="server">
        <h2><span>Editar Hotel Precio</span></h2>
                    
 
         <asp:Table ID="Table3" runat="server">
         <%--<asp:TableRow>
          <asp:TableCell><asp:Label ID="Label8" runat="server" Text="Ciudad: "> </asp:Label> </asp:TableCell> 
          <asp:TableCell>
          <asp:DropDownList ID="ddlCiudadAEditar" runat="server"  AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ciudad_OnSelectedIndexChanged" OnTextChanged="Ciudad_OnSelectedIndexChanged">
          </asp:DropDownList>              
          </asp:TableCell> 
         </asp:TableRow>--%>
          <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label9" runat="server" Text="Hotel: "> </asp:Label> </asp:TableCell> 
          <asp:TableCell>
          <asp:DropDownList ID="ddlEdithotel" runat="server"> </asp:DropDownList>              
          </asp:TableCell> 
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label10" runat="server" Text="Fecha Desde:"> </asp:Label>             
               </asp:TableCell><asp:TableCell> <asp:TextBox CssClass="form-control" ID="TXTFechaDEdit" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TXTFechaDEdit" Format="M/d/yyyy">
               </asp:CalendarExtender></asp:TableCell>  
        
         </asp:TableRow>
         <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label11" runat="server" Text="Fecha Hasta:"> </asp:Label> </asp:TableCell>
          <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTFechaHEdit" runat="server"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TXTFechaHEdit" Format="M/d/yyyy">
               </asp:CalendarExtender></asp:TableCell>         
         </asp:TableRow>
         
         
         </asp:Table>
         <asp:Table ID="Table4" runat="server">
         <asp:TableRow>
         <asp:TableCell Width="400" ><asp:Label ID="Label12" runat="server" Text=""> </asp:Label></asp:TableCell> 
         </asp:TableRow>
         </asp:Table>
         <asp:Table ID="Table5" runat="server">
          <asp:TableRow>
         <asp:TableCell Width="400" ><asp:Label ID="Label13" runat="server" Text="Detalle de habitación"> </asp:Label></asp:TableCell> 
         
         <asp:TableCell><asp:Label ID="Label14" runat="server" Text="Peso (00,00)"> </asp:Label></asp:TableCell> 
         <asp:TableCell><asp:Label ID="Label15" runat="server" Text="Dolar (00,00)"> </asp:Label></asp:TableCell>  
         </asp:TableRow>

         <asp:TableRow>
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTDetalleEdit" runat="server" ></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTPesoEdit" runat="server"></asp:TextBox></asp:TableCell> 
         <asp:TableCell><asp:TextBox CssClass="form-control" ID="TXTDolarEdit" runat="server"></asp:TextBox></asp:TableCell>  
         </asp:TableRow>           
        </asp:Table> 
       <h3><asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-large" Text="Guardar" onclick="SaveEdit_Click" /> 
         
         <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary btn-large" 
             onclick="cancel_Click" Text="Cancelar" Height="32px" /></h3>
         <br />
         <br />
         <br />
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
