using Examen_05112024.Manager;
using Examen_05112024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_05112024
{
    public partial class AdminScreen : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCorreo"] == null)
            {
                Response.Redirect("LoginScreen.aspx");
            }
            else
            {
                UsuarioManager usuarioManager = new UsuarioManager();
                string correo = Session["UsuarioCorreo"].ToString();
                if (!usuarioManager.EsUsuarioAdmin(correo))
                {
                    Response.Redirect("CursoScreen.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        CargarCursos();
                    }
                }
            }
        }

        private void CargarCursos()
        {
            var cursoManager = new CursoManager();
            gvCursosAdmin.DataSource = cursoManager.ObtenerCursos();
            gvCursosAdmin.DataBind();
        }

        protected void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            var cursoManager = new CursoManager();
            
            var nuevoCurso = new Cursos
            {
                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                FechaInicio = DateTime.Parse(txtFecha.Text),
                Duracion = int.Parse(txtDuracion.Text)
            };

            cursoManager.AgregarCurso(nuevoCurso);
            CargarCursos();
        }

        protected void btnBuscarEmail_Click(object sender, EventArgs e)
        {
            var usuarioManager = new UsuarioManager();
            gvUsuariosAdmin.DataSource = usuarioManager.ObtenerUsuarioPorCorreo(txtCorreo.Text);
            gvUsuariosAdmin.DataBind();

        }

        protected void gvCursosAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCursosAdmin.EditIndex = e.NewEditIndex;
            CargarCursos();
        }

        protected void gvCursosAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCursosAdmin.EditIndex = -1;
            CargarCursos();
        }

        protected void gvCursosAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtén el ID del curso
            int cursoID = Convert.ToInt32(gvCursosAdmin.DataKeys[e.RowIndex].Value);

            // Obtén los nuevos valores de las celdas

            GridViewRow row = gvCursosAdmin.Rows[e.RowIndex];
            string nuevoTitulo = ((TextBox)row.Cells[1].Controls[0]).Text;
            string nuevaDescripcion = ((TextBox)row.Cells[2].Controls[0]).Text;
            string nuevaFecha = ((TextBox)row.Cells[3].Controls[0]).Text;
            string nuevaDuracion = ((TextBox)row.Cells[4].Controls[0]).Text;

            // Actualiza los datos en la fuente de datos (por ejemplo, base de datos)
            var cursoActualizado = new Cursos
            {
                Titulo = nuevoTitulo,
                Descripcion = nuevaDescripcion,
                FechaInicio = DateTime.Parse(nuevaFecha),
                Duracion = int.Parse(nuevaDuracion)
            };

            // Aquí debes agregar el código para actualizar los datos en tu base de datos
            var cursoManager = new CursoManager();
            cursoManager.EditarCurso(cursoActualizado, cursoID);

            // Establece el GridView en modo de visualización
            gvCursosAdmin.EditIndex = -1;

            // Vuelve a enlazar los datos al GridView
            CargarCursos();
        }

        protected void gvCursosAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtén el índice de la fila que se está eliminando
            int index = e.RowIndex;

            // Obtén el ID del curso
            string cursoID = gvCursosAdmin.DataKeys[index].Value.ToString();

            // Elimina el curso de la fuente de datos (por ejemplo, base de datos)
            var cursoManager = new CursoManager();
            // Aquí debes agregar el código para eliminar el curso en tu base de datos
            cursoManager.EliminarCurso(int.Parse(cursoID));

            // Vuelve a enlazar los datos al GridView
            CargarCursos();
        }

    }
}