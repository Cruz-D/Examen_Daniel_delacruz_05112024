using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Examen_05112024.Models; //recordar llamar a esto para que detecte datacontext

namespace Examen_05112024.Manager
{
    public class inscripcionManager
    {

        // cadena de conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["GestionCursosDBConnectionString"].ConnectionString;

        // Contexto de la base de datos, que es la conexión a la base de datos
        private DataClassesDataContext _context;

        // Constructor que inicializa el contexto
        public inscripcionManager()
        {
            _context = new DataClassesDataContext(cadenaConexion);
        }

        // agregar inscripcion
        public void AgregarInscripcion(int CursoID, int UserID)
        {

            var inscripcion = new Inscripciones
            {
                CursoID = CursoID,
                UsuarioID = UserID
              
            };

            _context.Inscripciones.InsertOnSubmit(inscripcion);
            _context.SubmitChanges();

        }
        

    }
}