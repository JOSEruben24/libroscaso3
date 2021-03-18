using Libreria.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace Libreria
{
    /// <summary>
    /// Descripción breve de LibrosWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class LibrosWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(Description ="Consulta de todos los libros")]
        public List<Libro> ObtenerLibro()
        {
            using (LibreriaEntities conexion = new LibreriaEntities())
            {
                //select * from Libros;
                //List<Libro> consulta = from c in conexion.Libros select c;
                var consulta = from c in conexion.Libros select c;
               return consulta.ToList();
            }
        }
        [WebMethod(Description ="Agrega nuevos Libros")]
        public bool InsertarLibro(int id,String Titulo, string Autor,float Precio, int AñoPublicacion)
        {
            using (LibreriaEntities conexion = new LibreriaEntities())
            {
                Libro nuevo = new Libro();
                nuevo.Id = id;
                nuevo.Titulo = Titulo;
                nuevo.Autor = Autor;
                nuevo.Precio = Precio;
                nuevo.AñoPublicacion = AñoPublicacion;
                conexion.Libros.Add(nuevo);
                conexion.SaveChanges();
                return true;
            }
        }
        [WebMethod(Description = "elimina Libros")]
        public bool EliminarLibro(int id)
        {
            using (LibreriaEntities conexion = new LibreriaEntities())
            {
                var libro = (from c in conexion.Libros where c.Id == id select c).FirstOrDefault();
                if (libro != null)
                {
                    conexion.Libros.Remove(libro);
                    conexion.SaveChanges();
                }
                return true;
            }
        }
        [WebMethod(Description = "edita Libros")]
        public bool EditarLibro(int id, String Titulo, string Autor, float Precio, int AñoPublicacion)
        {
            using (LibreriaEntities conexion = new LibreriaEntities())
            {
                var libro = (from c in conexion.Libros where c.Id == id select c).FirstOrDefault();
                if (libro != null)
                {
                    libro.Id = id;
                    libro.Titulo = Titulo;
                    libro.Autor = Autor;
                    libro.Precio = Precio;
                    libro.AñoPublicacion = AñoPublicacion;
                    conexion.SaveChanges();
                }
                return true;
            }
        }
    }
}
