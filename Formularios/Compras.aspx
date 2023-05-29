<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="gestionInventario.Formularios.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Compras de Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
        .auto-style2 {
            flex: 0 0 auto;
            width: 66.66666667%;
            margin-right: 0px;
        }
        .auto-style3 {
            flex: 0 0 auto;
            width: 65%;
            margin-right: 0px;
        }
        .auto-style4 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container d-flex justify-content-center align-items-center" style="background-image: url(/Imagenes/Luffy.jpg);">
   <div class="auto-style3">
      <div class="align-items-center col-auto" >
          <div class="modal-title align-content-center h3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label runat="server" Text=" Compras" Font-Size="Larger" style="color: white;"></asp:Label>
         </div>
    
        <p class="auto-style1">
            
        <p style="color: #000000; font-size: medium; font-weight: 700; font-family: Arial, Helvetica, sans-serif">
            <asp:Label ID="Label10" runat="server" style="font-size: small; color: white;" Text="Numero de Factura:"></asp:Label>
            <asp:TextBox ID="txtnrofactura" runat="server" Width="129px"></asp:TextBox>
            <br />
           <asp:Label ID="Label9" runat="server" style="font-size: small; color: white;" Text="Fecha Venta:" ></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtfecha" runat="server" TextMode="Date" Width="129px"></asp:TextBox>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Observacion:" CssClass="auto-style1" style="color: white;"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtobservacion" runat="server" Width="129px">Efectivo</asp:TextBox>
        </p>
        <p>
            
            <asp:Label ID="Label1" runat="server" style="font-size: small;color: white; font-weight: 700; font-family: Arial, Helvetica, sans-serif" Text="Seleccionar Proveedor:"></asp:Label>
            <asp:DropDownList ID="proveedores" runat="server" AutoPostBack="True" DataSourceID="SqlDataProveedores" DataTextField="empresa" DataValueField="nit" Height="25px" OnSelectedIndexChanged="proveedores_SelectedIndexChanged" Width="175px">
            </asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="SqlDataProveedores" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionBDProyecto %>" SelectCommand="SELECT * FROM [proveedores]"></asp:SqlDataSource>
            
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Nit:" style="color: white;"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtnit" runat="server" Width="220px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Dirección:" style="color: white;"></asp:Label>
           <asp:TextBox ID="txtdireccion" runat="server" Width="220px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Teléfono: " style="color: white;"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txttelefono" runat="server" Width="220px"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Ciudad:" style="color: white;"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtciudad" runat="server" Width="220px"></asp:TextBox>
        </p>
        <p>
            </p>
        <table class="table table-dark" border="1" style="border-collapse: collapse">
         <tr>
           <td style="width: 200px"> Codigo:<br/>
             <asp:TextBox ID="txtcodigo" runat="server" Width="100" />
           </td>
           <td style="width: 200px"> Nombre:<br />
             <asp:TextBox ID="txtnombre" runat="server" Width="200" />
           </td>
           <td style="width: 150px"> cantidad:<br />
             <asp:TextBox ID="txtcantidad" runat="server" Width="150" />
           </td>
           <td style="width: 150px">valor unitario:<br />
             <asp:TextBox ID="txtvalor" runat="server" Width="150" />         
           </td>
           
           <td align="center"  valign="middle" style="width: 150px;">
            <asp:Button class="btn btn-primary" ID="btnAdd" runat="server" Text="Adicionar" OnClick="Button1_Click"/>
           </td>
        </tr>
       </table>
          <br />
          <asp:GridView ID="detalleproducto" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="108px" Width="757px">
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
            
            <asp:Label ID="Label12" runat="server" BackColor="Black" ForeColor="White" Text="Total de la Compra:"></asp:Label>
            <asp:TextBox ID="txttotalcompra" runat="server"></asp:TextBox>
        <br />
        <br />
            <asp:Button ID="Button2" runat="server" style=" position: relative; top: -2px; left: 368px;  background-color: #EF5350; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" Text="Guardar" OnClick="btnGuardar_Click"  />
            <br />
            <br />

        </div></div>
     
</asp:Content>

