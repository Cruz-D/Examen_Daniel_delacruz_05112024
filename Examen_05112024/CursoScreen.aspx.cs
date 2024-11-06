using Examen_05112024.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_05112024
{
    public partial class CursoScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCorreo"] == null)
            {
                Response.Redirect("LoginScreen.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarCursos();
                }
            }
        }

        //metodo de tipo databind para cargar datos en el gridview
        private void CargarCursos()
        {
            //instanciar el manager
            var cursoManager = new CursoManager();
            //cargar cursos en el gridview llamando al get
            gvCursos.DataSource = cursoManager.ObtenerCursos();
            //databind para cargar los datos
            gvCursos.DataBind();
        }

        //metodo para inscribirse en un curso al hacer click en el boton del gridview
        protected void gvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribirse")
            {
                //obtener el indice de la fila
                int index = Convert.ToInt32(e.CommandArgument);
                //obtener la fila
                GridViewRow row = gvCursos.Rows[index];
                //obtener el id del curso
                int cursoId = Convert.ToInt32(gvCursos.DataKeys[index].Value);

                // Registrar inscripción en la base de datos
                var inscripcionManager = new inscripcionManager();

                //obtener el usuario actual
                var usuarioManager = new UsuarioManager();

                //obtener el id del usuario actual
                var usuario = usuarioManager.ObtenerIdUsuario(Session["UsuarioCorreo"].ToString());

                //agregar inscripcion
                inscripcionManager.AgregarInscripcion(cursoId, usuario);
            }
        }

    }
}