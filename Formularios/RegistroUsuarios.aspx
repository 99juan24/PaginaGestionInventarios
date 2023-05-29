<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="gestionInventario.Formularios.RegistroUsuarios" %>

<!DOCTYPE html>

	<html xmlns="http://www.w3.org/1999/xhtml">

	<head runat="server">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet"
			integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"
			crossorigin="anonymous" />
		<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"
			integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"
			crossorigin="anonymous"></script>
		<script src="../js/codigo.js"></script>
		<title>Registro de Usuarios</title>
	</head>

	<body>
		<form id="frmusuario" runat="server">
			<section class="vh-100" style="background-color: #5dade2">
				<div class="container h-100">
					<div class="row d-flex justify-content-center align-items-center h-100">
						<div class="col-lg-12 col-xl-11">
							<div class="card text-black" style="border-radius: 25px">
								<div class="card-body p-md-5">
									<div class="row justify-content-center">
										<div
											class="col-md-10 col-lg-6 col-xl-5 row justify-content-center order-2 order-lg-1">
											<p class="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">
												Registro de Usuarios
											</p>

											<div class="input-group">
												<i class="fas fa-user fa-lg me-3 fa-fw"></i>
												<div class="form-outline flex-fill mb-0">
													<asp:Label ID="Label2" CssClass="form-label" runat="server"
														Text="Nombres"></asp:Label>
													<asp:TextBox ID="txtnombres" CssClass="form-control" runat="server"
														placeholder="Ej. Juan Camilo"></asp:TextBox>
												</div>
											</div>
											<br />
											<div class="input-group">
												<i class="fas fa-user fa-lg me-3 fa-fw"></i>
												<div class="form-outline flex-fill mb-0">
													<asp:Label ID="Label3" CssClass="form-label" runat="server"
														Text="Apellidos"></asp:Label>
													<asp:TextBox ID="txtapellidos" CssClass="form-control"
														runat="server" placeholder="Ej. Perez Hernandez "></asp:TextBox>
												</div>
											</div>
											<br />
											<div class="input-group">
												<i class="fas fa-calendar fa-lg me-3 fa-fw"></i>
												<div class="form-outline flex-fillmb-0">
													<asp:Label ID="Label4" CssClass="form-label" runat="server"
														Text="Fecha de nacimiento"></asp:Label>
													<asp:TextBox ID="txtfecha" CssClass="form-control" runat="server"
														TextMode="Date"></asp:TextBox>
												</div>
											</div>
											<br />
											<div class="input-group">
												<i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
												<div class="form-outline flex-fill mb-0">
													<asp:Label ID="Label5" CssClass="form-label" runat="server"
														Text="Usuario:"></asp:Label>
													<asp:TextBox ID="txtusuario" CssClass="form-control" runat="server"
														placeholder="Ej. juan00"></asp:TextBox>
												</div>
											</div>
											<br />
											<div class="input-group">
												<i class="fas fa-lock fa-lg me-3 fa-fw"></i>
												<div class="form-outline flex-fill mb-0">
													<asp:Label ID="Label6" CssClass="form-label" runat="server"
														Text="Contraseña:"></asp:Label>
													<asp:TextBox ID="txtclave" CssClass="form-control" runat="server"
														TextMode="Password" placeholder="Contraseña"></asp:TextBox>
												</div>
											</div>
											<br />
											<div class="input-group">
												<i class="fas fa-lock fa-lg me-3 fa-fw"></i>
												<div class="form-outline flex-fill mb-0">
													<asp:Label ID="Label8" CssClass="form-label" runat="server"
														Text="Repetir Contraseña:"></asp:Label>
													<asp:TextBox ID="txtclave2" CssClass="form-control" runat="server"
														TextMode="Password" placeholder="Repetir Contraseña">
													</asp:TextBox>
												</div>
											</div>
											<div>
												<br />
											</div>
											<div class="row justify-content-center">
												<asp:Image CssClass="img-thumbnail" alt="Sample image" runat="server"
													Width="150" Height="150" ImageUrl="~/Imagenes/agregar.png">
												</asp:Image>
											</div>
											<div>
												<script type="text/javascript">
                                                    function showimagepreview(input) {
                                                        if (input.files && input.files[0]) {
                                                            var reader = new FileReader();
                                                            reader.onload = function (e) {
                                                                document
                                                                    .getElementsByTagName("img")[0]
                                                                    .setAttribute("src", e.target.result);
                                                            };
                                                            reader.readAsDataURL(input.files[0]);
                                                        }
                                                    }
                                                </script>
											</div>
											<div class="row justify-content-center">
												<asp:FileUpload ID="FUImage" runat="server"
													onchange="showimagepreview(this)" />

												<img id="img" alt="" style="width: 300px" />
											</div>
											<div>
												<br />
												<br />
											</div>

											<asp:Label CssClass="alert-danger" runat="server" ID="lblerror"></asp:Label>
											<div class="row">
                                                <asp:Button runat="server" CssClass="form-control btn btn-primary"
                                                    Style="color: #fdfefe" Text="Registrar"  OnClick="Registrar_Click"/>
												<hr />
												<asp:Button runat="server" CssClass="form-control btn btn-danger"
													style="color: #fdfefe" Text="Cancelar"  OnClick="Cancelar_Click"/>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</section>
		</form>
	</body>

	</html>
