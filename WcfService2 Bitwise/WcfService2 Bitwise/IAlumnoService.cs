using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService2_Bitwise.Models;

namespace WcfService2_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumnoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]

        bool Actualizar(int id, string nombre, string dni, string domicilio, string ciudad);

        [OperationContract]

        bool Agregar(int id, string nombre, string dni, string domicilio, string ciudad);

        [OperationContract]

        AlumnoNuevo BuscarX(int id);

        [OperationContract]

        List<AlumnoNuevo> BuscarTablas();

        [OperationContract]

        bool Eliminar(int id);
    }
}
