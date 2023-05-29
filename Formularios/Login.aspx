<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="gestionInventario.Formularios.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <title>Inicio de Sesión</title>
</head>
<body style="background-color:#508bfc;">

    <form id="frmlogin" runat="server" class="vh-100">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card shadow-2-strong" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">
                            <div>
                                 <asp:Image runat="server" Height="150" src="/Imagenes/loogo_nakama-removebg-preview.png" />
                            </div>
                            <h3 class="mb-5">Iniciar Sesion</h3>

                            <div class="form-outline mb-4">
                                <asp:TextBox ID="txtusuario" CssClass="form-control form-control-lg" runat="server" placeholder="Usuario"></asp:TextBox>
                                
                            </div>
                            <br />
                            <div class="form-outline mb-4">
                                <asp:TextBox ID="txtclave" CssClass="form-control form-control-lg" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                               
                            </div>


                            <asp:Button runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Login" OnClick="Iniciar_Click" />

                            <div>
                                 <asp:Label runat="server" ID="lblerror" class="alert-danger" ></asp:Label>
                                  <br />
                                  <asp:Label runat="server" Text="¿No tienes cuenta?, Registrarse"></asp:Label>
                                  <asp:LinkButton runat="server" Text="Aqui" OnClick="Registrarse_Click" style="color: #3498DB" ></asp:LinkButton> 
                           </div> 
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
