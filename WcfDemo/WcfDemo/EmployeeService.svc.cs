using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmployeeService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmployeeService.svc o EmployeeService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmployeeService : IEmployeeService
    {
        public List<BookDetail> GetBookDetails()
        {
            BookDbEntities BookDbEntities = new BookDbEntities();
            return BookDbEntities.BookDetails.ToList();
        }
    }
}
