using Examen_05112024.Models; //recordar llamar a esto para que detecte datacontext
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Examen_05112024.Manager
{
    public class CursoManager
    {
        // cadena de conexion
        string cadenaConexion = ConfigurationManager.ConnectionStrings["GestionCursosDBConnectionString"].ConnectionString;

        // Contexto de la base de datos, que es la conexión a la base de datos
        private DataClassesDataContext _context;

        // Constructor que inicializa el contexto
        public CursoManager()
        {

            _context = new DataClassesDataContext(cadenaConexion);
        }

        // Listar los cursos
        public List<Cursos> ObtenerCursos()
        {
            return _context.Cursos.ToList();
          
        }

        public Cursos ObtenerCursoPorId(int cursoId)
        {
            return _context.Cursos.SingleOrDefault(c => c.CursoID == cursoId);
        }

        // Añadir un curso
        public void AgregarCurso(Cursos curso)
        {
            //agregar curso usando linQ
            _context.Cursos.InsertOnSubmit(curso);
            _context.SubmitChanges();
            ObtenerCursos();
        }

        // Editar un curso pasandole como parametro el curso a editar y el id
        public void EditarCurso(Cursos curso, int id)
        {
            //obtener curso por id
            var cursoEditar = _context.Cursos.SingleOrDefault(c => c.CursoID == id);
            if (cursoEditar != null)
            {
                cursoEditar.Titulo = curso.Titulo;
                cursoEditar.Descripcion = curso.Descripcion;
                cursoEditar.FechaInicio = curso.FechaInicio;
                cursoEditar.Duracion = curso.Duracion;

                //actualizar bbdd
                _context.SubmitChanges();   
            }
        }

        // Eliminar un curso
        public void EliminarCurso(int CursoId)
        {
            //obtener curso por id
            Cursos curso = _context.Cursos.FirstOrDefault(c => c.CursoID == CursoId);

            //ordenar borrado
            _context.Cursos.DeleteOnSubmit(curso);

            //actualizar bbdd
            _context.SubmitChanges();

        }
    }

}  