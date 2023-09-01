using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService1_Bitwise.Models;

namespace WcfService1_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnoService.svc o AlumnoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnoService : IAlumnoService
    {
        public bool Actualizar(int id, string dni, string nombre, string domicilio, string ciudad)
        {
            bool resultado = false;
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
            var alumno = db.AlumnoNuevo.Find(id);
                if (alumno != null)
                {
                    alumno.Dni = dni is null ? alumno.Dni : dni;
                    alumno.Nombre = nombre is null ? alumno.Nombre : nombre;
                    alumno.Domicilio = domicilio is null ? alumno.Domicilio : domicilio;
                    alumno.Ciudad = ciudad is null ? alumno.Ciudad : ciudad;

                    db.Entry(alumno).State = EntityState.Modified;
                    resultado = db.SaveChanges() > 0;
                }   
            }
            return resultado;
        }

        public bool agregar(int id,string dni, string nombre, string domicilio, string ciudad)
        {
            bool resultado = false;
            AlumnoNuevo alumno = new AlumnoNuevo 
            {
               Id = id,
               Dni= dni,
               Nombre= nombre,
               Domicilio= domicilio,
               Ciudad= ciudad
            };
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                db.AlumnoNuevo.Add(alumno);
                resultado = db.SaveChanges() > 0;
            }
            return resultado;
        }

        public AlumnoNuevo BuscarXDni(string dni)
        {
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                return db.AlumnoNuevo.FirstOrDefault(e => e.Dni == dni);
            }
        }

        public List<AlumnoNuevo> Consultar()
        {
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                return db.AlumnoNuevo.ToList();
            }
        }

        public bool Eliminar(string dni)
        {
            bool resultado = false;
            using (AlumnosBitwiseEntities db = new AlumnosBitwiseEntities())
            {
                AlumnoNuevo alumno = db.AlumnoNuevo.FirstOrDefault(x => x.Dni == dni);
                if (alumno != null) 
                {
                    db.AlumnoNuevo.Remove(alumno);
                    resultado = db.SaveChanges() > 0;
                }
                else
                {
                    resultado = false;
                }
                return resultado;
            }
        }
    }
}
