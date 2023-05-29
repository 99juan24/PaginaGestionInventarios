<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="gestionInventario.Formularios.Productos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    MIS PRODUCTOS
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        font-weight: bold;
        font-size: medium;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center " style="background-image: url(/Imagenes/Luffy.jpg);">
    <div class="col-6">
        <br />
        <br />
        <div class="modal-title align-content-center h3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label runat="server" Text=" Inventario" Font-Size="Larger" style="color: white;"></asp:Label>
         </div>
        <br />
        <br />
      <div class="align-items-center col-auto">
    <asp:Panel ID="Panel1" runat="server"  Width="493px">
        <asp:Label ID="Label1" runat="server" Text="Código Numerico:" style="color: white;" ></asp:Label>        
        <asp:TextBox ID="txtcodigo" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nombre Producto:" style="color: white;" ></asp:Label>
        <asp:TextBox ID="txtnombre" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Cantidad:" style="color: white;"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtcantidad" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Valor unitario:" style="color: white;"></asp:Label>
         &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="txtvalor" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <br />
        <br />
    </asp:Panel>
          <br />
          <br />
    <asp:GridView ID="DatosProductos" runat="server" CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
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
           <br />
           <br />
           <br />
          </div></div></div>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Sitio_Web_Full_Produccion.Formularios.ModeloProductosDataContext" EntityTypeName="" Select="new (codigo, nombre, cantidad, valorunitario)" TableName="Productos" OnSelecting="LinqDataSource1_Selecting"></asp:LinqDataSource>
</asp:Content>
