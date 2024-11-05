<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginScreen.aspx.cs" Inherits="Examen_05112024.LoginScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - Cursos online</title>
    <link href="Bootstrap/Content/bootstrap.css" rel="stylesheet" />
    <link href="Styles/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="login-form">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <h1 class="text-center display-4 mb-4">Cursos online</h1>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtEmail" class="form-label">Em@il</label>
                                <input type="email" id="txtEmail" class="form-control" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="txtPass" class="form-label">Contraseña</label>
                                <input type="password" id="txtPass" class="form-control" runat="server" />
                            </div>
                            <div class="form-group form-check">
                                <input type="checkbox" id="chkRemember" class="form-check-input" runat="server" />
                                <label for="chkRemember" class="form-check-label">Recordar contraseña</label>
                            </div>
                            <div class="form-group text-center">
                                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Bootstrap/Scripts/bootstrap.js"></script>
</body>
</html>
