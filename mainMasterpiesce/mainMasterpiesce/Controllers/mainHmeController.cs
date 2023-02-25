using mainMasterpiesce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mainMasterpiesce.Controllers
{
    public class mainHomeController : Controller
    {
        FindingpeaceEntities doct = new FindingpeaceEntities();
        // GET: mainHome
        public ActionResult Index()
        { bool flag = true;
            var existuser = User.Identity.GetUserId();

            var ASPEmail = doct.AspNetUsers.Where(c => c.Id == existuser).Select(c => c.Email).FirstOrDefault();
            var patientEmail = doct.patients.FirstOrDefault(c => c.patientemail == ASPEmail);
            var doctorEmail = doct.doctors.FirstOrDefault(c => c.email== ASPEmail);
            var role = doct.AspNetUserRoles.ToList();
        
        var doctors=doct.doctors.ToList();
            var specializations=doct.specializations.ToList();

            return View(Tuple.Create(doctors, specializations));
        }



        public ActionResult ConTact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult test()
        {
            return View();
        }

        public ActionResult Aboutt()
        {
            return View();
        }


    }
}