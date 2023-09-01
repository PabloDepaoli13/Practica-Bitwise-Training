using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService4_Bitwise.Models;

namespace WcfService4_Bitwise
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumnosService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumnosService
    {
        [OperationContract]
        bool Agregar(string nombre, string dni, string domicilio, string ciudad);

        [OperationContract]
        bool Actualizar(int id, string nombre, string dni, string domicilio, string ciudad);

        [OperationContract]

        List<AlumnosQuimica> MostrarTabla();

        [OperationContract]

        AlumnosQuimica BuscarAlumno(int id);

        [OperationContract]

        bool EliminarTabla(int id);
    }
}
