using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudentsService.Controllers
{
    public class StudentsServiceController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}