<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CursoScreen.aspx.cs" Inherits="Examen_05112024.CursoScreen" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Gestión de Cursos</title>
    <link href="Styles/CursosStyle.css" rel="stylesheet" />
    <link href="Bootstrap/Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container-grid">
            <div class="header-title">
                Proximos Cursos
            </div>

            <div class="course-table">
                <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Titulo" HeaderText="Título" ItemStyle-Width="20%" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="40%" />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" ItemStyle-Width="20%" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Duracion" HeaderText="Duración (días)" ItemStyle-Width="10%" />
                        <asp:ButtonField Text="Inscribirse" CommandName="Inscribir" ButtonType="Button" ItemStyle-Width="10%" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="Bootstrap/Scripts/bootstrap.js"></script>
</body>
</html>
