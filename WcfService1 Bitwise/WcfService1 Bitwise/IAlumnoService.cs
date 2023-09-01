using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService1_Bitwise.Models;

namespace WcfService1_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumnoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumnoService
    {
        [OperationContract]

        bool Actualizar(int id, string dni, string nombre, string domicilio, string ciudad);

        [OperationContract]

        bool agregar(int id, string dni, string nombre, string domicilio, string ciudad);

        [OperationContract]

        AlumnoNuevo BuscarXDni(string dni);

        [OperationContract]

        List<AlumnoNuevo> Consultar();

        [OperationContract]

        bool Eliminar(string dni);
    }
}
