using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmployeeService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<BookDetail> GetBookDetails();
    }
}
