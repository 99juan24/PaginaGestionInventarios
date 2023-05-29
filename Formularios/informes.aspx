<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="informes.aspx.cs" Inherits="gestionInventario.Formularios.informes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="background-image: url(/Imagenes/Luffy.jpg);">
   <div class="auto-style3">
 
   
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div style="width: 800px; height: 600px;">
            <asp:DropDownList ID="ddlTabla" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTabla_SelectedIndexChanged">
       <asp:ListItem Text="Clientes" Value="Clientes"></asp:ListItem>
      <asp:ListItem Text="Productos" Value="Productos"></asp:ListItem>
     <asp:ListItem Text="proveedores" Value="proveedores"></asp:ListItem>
      </asp:DropDownList>
    <br />
    <br />
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"></rsweb:ReportViewer>
     </div>
    </div>
        </div>
</asp:Content>
