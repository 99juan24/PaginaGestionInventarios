<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="gestionInventario.Formularios.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
     Proveedores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-left align-items-left" style="background-image: url(/Imagenes/Luffy.jpg);">
    <div class="col-6">
      <div class="align-items-center col-auto">
        <div class="modal-title align-content-center h3">
          <asp:Label runat="server" Text="Nuestros Proveedores" Font-Size="Larger" style="color: white;"></asp:Label>
         </div>
   
        <table class="table table-dark" border="1" style="border-collapse: collapse">
         <tr>
           <td style="width: 200px"> NIT:<br/>
             <asp:TextBox ID="txtnit" runat="server" Width="100" />
           </td>
           <td style="width: 200px"> Empresa:<br />
             <asp:TextBox ID="txtepresa" runat="server" Width="200" />
           </td>
           <td style="width: 150px"> Dirección:<br />
             <asp:TextBox ID="txtdireccion" runat="server" Width="150" />
           </td>
           <td style="width: 150px">Teléfono:<br />
             <asp:TextBox ID="txttelefono" runat="server" Width="150" />         
           </td>
           <td style="width: 150px"> Ciudad:<br />
             <asp:TextBox ID="txtciudad" runat="server" Width="150" />
           </td>
           <td align="center"  valign="middle" style="width: 150px;">
            <asp:Button class="btn btn-primary" ID="btnAdd" runat="server" Text="Adicionar" OnClick="Insertar" />
           </td>
        </tr>
       </table>
       <br />
       <br />
      
       <table border="1" style="border-collapse: collapse" align="center">
          <tr><td>
             <asp:GridView ID="tablaprveedores" runat="server" AutoGenerateColumns="False"
                 DataKeyNames="nit" AllowPaging="True" PageSize="5" OnPageIndexChanging = 
                 "OnPaging" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
                 OnRowDataBound="OnRowDataBound" OnRowUpdating="OnRowUpdating" 
                 OnRowDeleting="OnRowDeleting" EmptyDataText="Registro no adicionado." CellPadding="4" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
               <Columns>
                 <asp:BoundField DataField="nit" HeaderText="nit" InsertVisible="False" 
                     ReadOnly="True" SortExpression="nit"  />
                 <asp:BoundField DataField="empresa" HeaderText="epresa" 
                     SortExpression="nombre" />
                 <asp:BoundField DataField="direccion" HeaderText="Dirección" 
                     SortExpression="direccion" />
                 <asp:BoundField DataField="telefono" HeaderText="Teléfono" 
                     SortExpression="telefono" />
                 <asp:BoundField DataField="ciudad" HeaderText="Ciudad" 
                     SortExpression="ciudad" />
                 <asp:CommandField ShowEditButton="True" ButtonType="Button" ControlStyle-ForeColor="White" ControlStyle-BackColor="Green"  />
                  <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-ForeColor="White" ControlStyle-BackColor="Red" />
               </Columns>
                 <FooterStyle BackColor="#17202A" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#17202A" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                 <RowStyle BackColor="#AED6F1" ForeColor="#333333" />
                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                 <SortedAscendingCellStyle BackColor="#AED6F1" />
                 <SortedAscendingHeaderStyle BackColor="#D6EAF8" />
                 <SortedDescendingCellStyle BackColor="#AED6F1" />
                 <SortedDescendingHeaderStyle BackColor="#D6EAF8" />
           </asp:GridView>
         </td></tr>
       </table>  
        
          <br />
          <br />
     </div>
   </div>
 </div>
</asp:Content>
