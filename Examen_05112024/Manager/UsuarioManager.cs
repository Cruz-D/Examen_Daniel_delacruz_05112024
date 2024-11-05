using Examen_05112024.Models; //recordar llamar a esto para que detecte datacontext
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace Examen_05112024.Manager
{
    public class UsuarioManager
    {
        // cadena de conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["GestionCursosDBConnectionString"].ConnectionString;

        // Contexto de la base de datos, que es la conexión a la base de datos
        private DataClassesDataContext _context;

        // Constructor que inicializa el contexto
        public UsuarioManager()
        {
            _context = new DataClassesDataContext(cadenaConexion);
        }
        // funcion de autenticacion de usuario
        public bool Autenticar(string correo, string contraseña)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Correo == correo && u.Contraseña == contraseña);
            return usuario != null;
        }

        // funcion para obtener ID DEL USUARIO
        public int ObtenerIdUsuario(string correo)
        {
            // se busca el usuario por el correo
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Correo == correo);
            // si el usuario no es nulo se retorna el ID del usuario
            return usuario != null ? usuario.UsuarioID : 0;
        }

        public List<Usuarios> ObtenerUsuarioPorCorreo(string correo)
        {
            return _context.Usuarios.Where(c => c.Correo == correo).ToList();
        }

        public bool EsUsuarioAdmin(string correo)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Correo == correo);
            return usuario != null && usuario.Rol == "Admin";
        }
    }
}

