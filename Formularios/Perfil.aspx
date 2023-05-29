<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="gestionInventario.Formularios.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Mi Perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container " >
        <fieldset class="row">
            <div class="container text-black-50 row" style="background-image: url(/Imagenes/Luffy.jpg);">
                <div class="col-6 row justify-content-center">
                    <div class="align-items-center col-auto">
                        <fieldset>
                            <div class="row">
                                <asp:Image runat="server" ID="image" CssClass="form-control img-thumbnail" Height="300"></asp:Image>
                            </div>
                            <div class="row">
                                <asp:FileUpload runat="server" ID="FUImage" CssClass="form-control form-control-sm" ></asp:FileUpload>
                            </div>
                            <div class="row">
                                <asp:Button runat="server" ID="BtnAplicar" Text="Aplicar Cambios" CssClass="form-control btn btn-primary btn-rounded" OnClick="btnAplicarCambios_Click" />
                            </div>
                        </fieldset>
                    </div>
                    <div class="row">
                      <asp:Label runat="server" ID="lblerror" CssClass=" alert-danger"></asp:Label>
                    </div>
                </div>
                <div class="col-6 row justify-content-center">
                    <div class="align-items-center col-auto">
                        <fieldset>
                            <legend>
                                <i class="fade fa-Database">Datos Personales</i>
                            </legend>
                            <asp:Table runat="server" Enabled="false">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Nombres" style="color:#FDFEFE"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtnombres"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Apellidos" style="color:#FDFEFE"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtapellidos"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Fecha de Nacimiento" style="color:#FDFEFE"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtfecha"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </fieldset>
                        <br />
                        <fieldset>
                            <legend>
                                <i class="fade fa-key">Datos de sesión</i>
                            </legend>
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Usuario" style="color:#FDFEFE"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtusuario" Enabled="false"></asp:TextBox>
                                    </asp:TableCell>
                                 </asp:TableRow>
                                 <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button runat="server" CssClass="form-control btn btn-primary" ID="btnCambiar" OnClick="btnCambiar_Click" Text="Cambiar contraseña"></asp:Button>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button runat="server" CssClass="form-control btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" Text="Guardar" Visible="false"></asp:Button>
                                    </asp:TableCell>                                
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Table runat="server" ID="contrasena" Visible="false">
                                <asp:TableRow >
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Nueva Contraseña" style="color:#FDFEFE"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" ID="clave" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    </asp:TableCell>
                                 </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Confirmar Contraseña" style="color:#FDFEFE"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" ID="clave2" CssClass="form-control" TextMode="Password" placeholder="Repetir Password"></asp:TextBox>
                                    </asp:TableCell>
                                 </asp:TableRow>
                            </asp:Table>
                            <asp:Label runat="server" ID="lblerrorclave" CssClass="alert-danger"></asp:Label>
                        </fieldset>
                    </div>
                </div>
            </div>
        </fieldset>
        <br />
        <br />
        <div class="container d-flex justify-content-center">
            <asp:Button runat="server" class="btn bg-danger" Text="Eliminar cuenta" ForeColor="White" OnClick="eliminar_Click"/>
        </div>
    </div>
</asp:Content>