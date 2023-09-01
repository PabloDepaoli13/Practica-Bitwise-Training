using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;
using WcfService2_Bitwise.Models;

namespace WcfService2_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnoService.svc o AlumnoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnoService : IAlumnoService
    {
        public bool Actualizar(int id, string nombre, string dni, string domicilio, string ciudad)
        {
            bool resultado = false;
            using (AlumnosBitwiseEntities1 db = new AlumnosBitwiseEntities1())
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

        public bool Agregar(int id, string nombre, string dni, string domicilio, string ciudad)
        {
            bool resultado = false;
            AlumnoNuevo alumno = new AlumnoNuevo 
            {
                Id= id,
                Nombre = nombre,
                Dni = dni,
                Domicilio = domicilio,
                Ciudad = ciudad
            };
            using (AlumnosBitwiseEntities1 db = new AlumnosBitwiseEntities1())
            {
                db.AlumnoNuevo.Add(alumno);
                resultado = db.SaveChanges() > 0;
            }
            return resultado;
        }

        public List<AlumnoNuevo> BuscarTablas()
        {
            using (AlumnosBitwiseEntities1 db = new AlumnosBitwiseEntities1())
            {
                return db.AlumnoNuevo.ToList();
            }
        }

        public AlumnoNuevo BuscarX(int id)
        {
            AlumnoNuevo alumno = null;
            using (AlumnosBitwiseEntities1 db = new AlumnosBitwiseEntities1())
            {
                alumno = db.AlumnoNuevo.FirstOrDefault(a => a.Id == id);
            }
            return alumno;
        }

        public bool Eliminar(int id)
        {
            bool resultado = false;
            using (AlumnosBitwiseEntities1 db = new AlumnosBitwiseEntities1())
            {
                AlumnoNuevo alumno = db.AlumnoNuevo.FirstOrDefault(e => e.Id == id);
                if (alumno != null)
                {
                    db.AlumnoNuevo.Remove(alumno);
                    resultado = db.SaveChanges() > 0;
                }
            }
            return resultado;
        }
    }
}
