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
            var usuarioManager = new UsuarioManager();

            string email = txtEmail.Value; 
            string password = txtPass.Value; 

            if (usuarioManager.Autenticar(email, password))
            {
                Session["UsuarioCorreo"] = email;
                if (usuarioManager.EsUsuarioAdmin(email))
                {
                    Response.Redirect("AdminScreen.aspx");
                }
                else
                {
                    Response.Redirect("CursoScreen.aspx");
                }
            }
        
        }
    }
}