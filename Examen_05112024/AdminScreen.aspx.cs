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
                //obtener el correo del usuario
                string correo = Session["UsuarioCorreo"].ToString();
                //verificar si el usuario es admin
                if (!usuarioManager.EsUsuarioAdmin(correo))
                {
                    //si no es admin redirigir a la pantalla de cursos
                    Response.Redirect("CursoScreen.aspx");
                }
                else
                {
                    //si es admin cargar los cursos
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
            // instanciar el manager
            var cursoManager = new CursoManager();

            // Crear un nuevo curso con los datos del formulario
            var nuevoCurso = new Cursos
            {
                Titulo = txtTitulo.Text,
                Descripcion = txtDescripcion.Text,
                FechaInicio = DateTime.Parse(txtFecha.Text),
                Duracion = int.Parse(txtDuracion.Text)
            };

            // Agregar el curso a la base de datos
            cursoManager.AgregarCurso(nuevoCurso);

            // Vuelve a enlazar los datos al GridView
            CargarCursos();
        }

        protected void btnBuscarEmail_Click(object sender, EventArgs e)
        {
            // instanciar el manager
            var usuarioManager = new UsuarioManager();
            // Cargar los usuarios con el correo ingresado
            gvUsuariosAdmin.DataSource = usuarioManager.ObtenerUsuarioPorCorreo(txtCorreo.Text);
            // Enlazar los datos al GridView
            gvUsuariosAdmin.DataBind();

        }

        protected void gvCursosAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Establece el índice de la fila editada
            gvCursosAdmin.EditIndex = e.NewEditIndex;
            gvCursosAdmin.DataBind();
            CargarCursos();
        }

        protected void gvCursosAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Establece el GridView en modo de visualización
            gvCursosAdmin.EditIndex = -1;
            // Vuelve a enlazar los datos al GridView
            CargarCursos();
        }

        protected void gvCursosAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener el ID del curso
            int cursoID = Convert.ToInt32(gvCursosAdmin.DataKeys[e.RowIndex].Value);


            // Obtener los nuevos valores de los campos de texto
            GridViewRow row = gvCursosAdmin.Rows[e.RowIndex];
            string nuevoTitulo = ((TextBox)row.Cells[1].Controls[0]).Text;
            string nuevaDescripcion = ((TextBox)row.Cells[2].Controls[0]).Text;
            string nuevaFecha = ((TextBox)row.Cells[3].Controls[0]).Text;
            string nuevaDuracion = ((TextBox)row.Cells[4].Controls[0]).Text;

            // Crear un nuevo objeto Curso con los nuevos valores
            var cursoActualizado = new Cursos
            {
                Titulo = nuevoTitulo,
                Descripcion = nuevaDescripcion,
                FechaInicio = DateTime.Parse(nuevaFecha),
                Duracion = int.Parse(nuevaDuracion)
            };

            // se instancia el manager
            var cursoManager = new CursoManager();

            // se llama al metodo de editar curso
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

            // instanciar el manager
            var cursoManager = new CursoManager();
            // llamar al metodo de eliminar curso
            cursoManager.EliminarCurso(int.Parse(cursoID));

            // Vuelve a enlazar los datos al GridView
            CargarCursos();
        }

    }
}