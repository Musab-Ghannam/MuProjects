using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mainMasterpiesce.Controllers
{
    public class DoctorEnrollingController : Controller
    {
        // GET: DoctorEnrolling
        [Authorize(Roles = "doctor")]
        public ActionResult EnrollDoctor()
        {
            return View();
        }
    }
}