using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiForManageVisitors.Controllers
{
    public class HomeController : Controller
    {
        public void CheckViewBagData()
        {
            @ViewBag.EmployeeRegistration = false;
            @ViewBag.VisitorRegistration = false;
            @ViewBag.EmployeeDepartment = false;
            @ViewBag.EmployeeDesignation = false;
        }

        public ActionResult Index()
        {
            CheckViewBagData();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}