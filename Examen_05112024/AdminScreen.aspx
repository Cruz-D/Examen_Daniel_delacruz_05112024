<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminScreen.aspx.cs" Inherits="Examen_05112024.AdminScreen" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Administración de Cursos</title>
    <link href="Bootstrap/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/AdminStyle.css" rel="stylesheet" />
    <style>
        /* Estilos de CSS Grid para crear una cuadrícula responsiva */
        .parent {
            display: grid;
            grid-template-columns: 1fr 2fr;
            gap: 1rem;
            padding: 1rem;
        }

        .div1, .div3, .div4 {
            background-color: #f8f9fa;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 1rem;
        }

        /* Estilos para pantallas grandes */
        @media (min-width: 992px) {
            .parent {
                grid-template-columns: 1fr 2fr;
                grid-template-rows: auto;
            }
            .div1 {
                grid-column: 1 / 2;
                grid-row: 1;
            }
            .div3 {
                grid-column: 1 / 2;
                grid-row: 2;
            }
            .div4 {
                grid-column: 2 / 3;
                grid-row: span 2;
            }
        }

        /* Estilos para pantallas medianas */
        @media (max-width: 991px) {
            .parent {
                grid-template-columns: 1fr;
                grid-template-rows: auto;
            }
            .div1, .div3, .div4 {
                grid-column: span 1;
                grid-row: auto;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="parent">
            <!-- Div para buscar por email -->
            <div class="div1">
                <div class="card">
                    <div class="card-header">
                        Buscar por email
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="searchEmail" class="form-label">Buscar por email</label>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control" Placeholder="Correo a buscar"></asp:TextBox>
                            <asp:Button ID="btnEmail" runat="server" Text="Busqueda" CssClass="btn btn-primary mt-1" OnClick="btnBuscarEmail_Click" />
                        </div>
                        <div>
                            <asp:GridView ID="gvUsuariosAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                    <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            
            <!-- Div para añadir un curso -->
            <div class="div3">
                <div class="card">
                    <div class="card-header">
                        Añadir Curso
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="txtTitulo" class="form-label">Título</label>
                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" Placeholder="Título del curso"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtDescripcion" class="form-label">Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Descripción del curso"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtFecha" class="form-label">Fecha de inicio</label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Placeholder="Fecha de inicio"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtDuracion" class="form-label">Duración en Horas</label>
                            <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control" Placeholder="Duración del curso"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregarCurso" runat="server" Text="Agregar Curso" CssClass="btn btn-primary mt-1" OnClick="btnAgregarCurso_Click" />
                    </div>
                </div>
            </div>

            <!-- Div para la tabla de administración de cursos -->
            <div class="div4">
                <asp:GridView ID="gvCursosAdmin" runat="server" 
                    AutoGenerateColumns="False" 
                    DataKeyNames="CursoID"
                    OnRowEditing="gvCursosAdmin_RowEditing"
                    OnRowCancelingEdit="gvCursosAdmin_RowCancelingEdit"
                    OnRowUpdating="gvCursosAdmin_RowUpdating"
                    OnRowDeleting="gvCursosAdmin_RowDeleting"
                    CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="CursoID" HeaderText="ID" />
                        <asp:BoundField DataField="Titulo" HeaderText="Título" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha inicio" />
                        <asp:BoundField DataField="Duracion" HeaderText="Duración" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="Bootstrap/Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
