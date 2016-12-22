using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            EmployeeService.EmployeeServiceClient objEmployee = new EmployeeService.EmployeeServiceClient();

            return View(objEmployee.GetBookDetails());
        }
	}
}