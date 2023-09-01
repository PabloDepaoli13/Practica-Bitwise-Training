using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService4_Bitwise.Models;

namespace WcfService4_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnosService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnosService.svc o AlumnosService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnosService : IAlumnosService
    {
        public bool Actualizar(int id, string nombre, string dni, string domicilio, string ciudad)
        {
            bool resultado = false;
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                AlumnosQuimica alumno = db.AlumnosQuimica.Find(id);
                if (alumno != null)
                {
                    alumno.Nombre = nombre is null ? alumno.Nombre : nombre;
                    alumno.Dni = dni is null ? alumno.Dni : dni;
                    alumno.Domicilio = domicilio is null ? alumno.Domicilio : domicilio;
                    alumno.Ciudad = ciudad is null ? alumno.Ciudad : ciudad;
                    db.Entry(alumno).State = EntityState.Modified;
                    resultado = db.SaveChanges() > 0;
                }
            }
            return resultado;
        }

        public bool Agregar(string nombre, string dni, string domicilio, string ciudad)
        {
            var resultado = false;  
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                AlumnosQuimica alumno = new AlumnosQuimica 
                {
                    Nombre = nombre,
                    Dni = dni,
                    Domicilio = domicilio,
                    Ciudad = ciudad
                };
                db.AlumnosQuimica.Add(alumno);
                resultado = db.SaveChanges() > 0;
            }
            return resultado;
        }

        public AlumnosQuimica BuscarAlumno(int id)
        {
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                return db.AlumnosQuimica.FirstOrDefault(e => e.Id == id);
            }
        }

        public bool EliminarTabla(int id)
        {
            bool resultado = false;
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                AlumnosQuimica alumno = db.AlumnosQuimica.Find(id);
                db.AlumnosQuimica.Remove(alumno);
                resultado = db.SaveChanges() > 0;
            }
            return resultado;
        }

        public List<AlumnosQuimica> MostrarTabla()
        {
            
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                return db.AlumnosQuimica.ToList();
            }
           
        }
    }
}
