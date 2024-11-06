using Examen_05112024.Manager;
using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace Examen_05112024
{
    public partial class LoginScreen : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // instanciar el manager
            var usuarioManager = new UsuarioManager();

            // obtener los datos del formulario
            string email = txtEmail.Value; 
            string password = txtPass.Value;

            // autenticar al usuario y redirigir a la pantalla correspondiente
            if (usuarioManager.Autenticar(email, password))
            {
                // guardar el correo del usuario en la sesión
                Session["UsuarioCorreo"] = email;

                // redirigir a la pantalla correspondiente
                if (usuarioManager.EsUsuarioAdmin(email))
                {
                    //si es admin redirigir a la pantalla de admin
                    Response.Redirect("AdminScreen.aspx");
                }
                else
                {
                    //si no es admin redirigir a la pantalla de cursos
                    Response.Redirect("CursoScreen.aspx");
                }
            }
        
        }
    }
}