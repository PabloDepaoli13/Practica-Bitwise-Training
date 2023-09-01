using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService3_Bitwise.Models;

namespace WcfService3_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumnoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]

        bool AgregarAlumno(int id, string dni, string nombre, string domicilio, string ciudad);

        [OperationContract]

        List<AlumnoNuevo> MostrarTablas();

        [OperationContract]

        bool ActualizarAlumno(int id, string dni, string nombre, string domicilio, string ciudad);

        [OperationContract]

        bool EliminarTabla(int id);

        [OperationContract]

        List<AlumnoNuevo> BuscarPorNombre(string nombre);


    }
}
