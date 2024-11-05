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

        private void CargarCursos()
        {
            var cursoManager = new CursoManager();
            gvCursos.DataSource = cursoManager.ObtenerCursos();
            gvCursos.DataBind();
        }

        protected void gvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribirse")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCursos.Rows[index];
                int cursoId = Convert.ToInt32(gvCursos.DataKeys[index].Value);

                // Registrar inscripción en la base de datos
                var inscripcionManager = new inscripcionManager();

                var usuarioManager = new UsuarioManager();

                var usuario = usuarioManager.ObtenerIdUsuario(Session["UsuarioCorreo"].ToString());
                
                inscripcionManager.AgregarInscripcion(cursoId, usuario);
            }
        }

    }
}