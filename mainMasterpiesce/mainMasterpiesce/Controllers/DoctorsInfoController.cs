using mainMasterpiesce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mainMasterpiesce.Controllers
{
    public class DoctorsInfoController : Controller
    {
        // GET: DoctorsInfo
        FindingpeaceEntities doc=new FindingpeaceEntities();

        //public ActionResult alldoctors(string therapistName, int? specializationsearch)
        //{
        //    var alldoctors = doc.doctors.ToList();
        //    var specialization = doc.specializations.ToList();

        //    if (therapistName != null)
        //    {
        //        var searchDoctor = doc.doctors.Where(c => c.doctorName.Contains(therapistName)).ToList();

        //        return View(Tuple.Create(searchDoctor, specialization));
        //    }
        //    else if (specializationsearch.HasValue)
        //    {
        //        var searchDoctor = doc.doctors.Where(c => c.specializationId == specializationsearch.Value).ToList();

        //        return View(Tuple.Create(searchDoctor, specialization));
        //    }
        //    else
        //    {
        //        return View(Tuple.Create(alldoctors, specialization));
        //    }
        //}


        public ActionResult alldoctors(string therapistName, string specializationsearch,string Male,string rating,string therapytype,string desc)
        {
         



            var alldoctors = doc.doctors.Where(c=>c.statedoctor==1).ToList();
            var specialization = doc.specializations.ToList();
            int therapyTypeInt, ratingInt;
            var accepteddoctors=doc.doctors.Where(c=>c.statedoctor==1).ToList();
       if(desc!=null&&desc=="highest")
            {
                var highestrate = doc.doctors.Where(c=>c.statedoctor == 1).OrderByDescending(c => c.ratingdoctor).ToList();

           
                return View(Tuple.Create(highestrate, specialization));
            }else if(desc != null && desc == "lowest")
            {

                var lowestprice = doc.doctors.Where(c => c.statedoctor == 1).OrderBy(c => c.pricePerHour).ToList();
                return View(Tuple.Create(lowestprice, specialization));

            }



            if (therapistName != null)
            {
                var searchDoctor = doc.doctors.Where(c => c.doctorName.Contains(therapistName)&&c.statedoctor==1).ToList();

                return View(Tuple.Create(searchDoctor, specialization));

            }

            //if (specializationsearch != null)
            //{
            //    var searchspaecialization = doc.doctors.Where(c => c.specializationId == Convert.ToInt16(specializationsearch)).ToList();

            //    return View(Tuple.Create(searchspaecialization, specialization));
            //}
            //male=
            if (Male != null && Male == Convert.ToString(1)&& rating==null&& therapytype==null)
            {

                var genderfiltering = doc.doctors.Where(c => c.Gender == true && c.statedoctor == 1).ToList();
                return View(Tuple.Create(genderfiltering, specialization));
            }
            else if (Male != null && Male == Convert.ToString(0) && rating == null && therapytype == null)
            {
                var genderfiltering0 = doc.doctors.Where(c => c.Gender == false && c.statedoctor == 1).ToList();
                return View(Tuple.Create(genderfiltering0, specialization));
            }
            //rating

            if (rating != null && therapytype == null && Male == null)
            {
                int ratingdecimalradio = Convert.ToInt16(rating);
                var ratingdoctor = doc.doctors.Where(c => c.statedoctor == 1 &&c.ratingint == ratingdecimalradio)
                                             .ToList();

                return View(Tuple.Create(ratingdoctor, specialization));








                //return View(Tuple.Create(ratingdoctor, specialization));
                //foreach (var item in ratingdoctor)
                //{
                //    //if (Convert.ToInt32(rating) ==Math.Round(Convert.ToDecimal(item.ratingdoctor)))
                //    //{
                //        int ratingIntt = Convert.ToInt32(rating);
                //         decimal RATINGDOCROUD =Math.Round(Convert.ToDecimal(item.ratingdoctor));
                //    if(ratingIntt == Convert.ToInt32(RATINGDOCROUD)) {






            }

            if (Male==null&&rating==null&& int.TryParse(therapytype, out therapyTypeInt))
            {
                var therapyfiltering= doc.doctors.Where(c => c.specializationId == therapyTypeInt && c.statedoctor == 1).ToList();
                return View(Tuple.Create(therapyfiltering, specialization));

            }
            //1 all exist and female


            if (int.TryParse(therapytype, out therapyTypeInt) && int.TryParse(rating, out ratingInt)&& Male == Convert.ToString(0))
            {
                var generalfiltering = doc.doctors.Where(c => c.specializationId == therapyTypeInt && c.ratingint == ratingInt&& c.Gender == false && c.statedoctor == 1).ToList();
                return View(Tuple.Create(generalfiltering, specialization));
            }
            //all exist and maleALL
            if (int.TryParse(therapytype, out therapyTypeInt) && int.TryParse(rating, out ratingInt) && Male == Convert.ToString(1))
            {
                var generalfiltering = doc.doctors.Where(c => c.specializationId == therapyTypeInt && c.ratingint == ratingInt && c.Gender == true && c.statedoctor == 1).ToList();
                return View(Tuple.Create(generalfiltering, specialization));
            }
            //2exist gender and thyarapytyprgender=0
            if(Male== Convert.ToString(0)&& int.TryParse(therapytype, out therapyTypeInt) && rating ==null) { 
            
                var filtergendtherapy0=doc.doctors.Where(c=>c.Gender==false&&c.specializationId==therapyTypeInt && c.statedoctor == 1).ToList();

                return View(Tuple.Create(filtergendtherapy0, specialization));


            }
            //2exist gender and thyarapytyprgender=1
            if (Male == Convert.ToString(1) && int.TryParse(therapytype, out therapyTypeInt) && rating == null)
            {

                var filtergendtherapy1 = doc.doctors.Where(c => c.Gender == true && c.specializationId == therapyTypeInt && c.statedoctor == 1).ToList();

                return View(Tuple.Create(filtergendtherapy1, specialization));


            }   //2exist therapytype and rating...
            if (Male ==null&& int.TryParse(therapytype, out therapyTypeInt) && int.TryParse(rating, out ratingInt))
            {

                var filterratingtherapy = doc.doctors.Where(c => c.ratingint == ratingInt && c.specializationId == therapyTypeInt && c.statedoctor == 1).ToList();

                return View(Tuple.Create(filterratingtherapy, specialization));


            }
            //2exist gender and rating=0
            if (Male == Convert.ToString(0) && therapytype == null && int.TryParse(rating, out ratingInt))
            {

                var filtergendrating0 = doc.doctors.Where(c => c.Gender == false && c.ratingint == ratingInt && c.statedoctor == 1).ToList();

                return View(Tuple.Create(filtergendrating0, specialization));


            }
            //2exist gender and rating=1
            if (Male == Convert.ToString(1) && therapytype==null && int.TryParse(rating, out ratingInt))
            { 

                var filtergendrating1 = doc.doctors.Where(c => c.Gender == true && c.ratingint == ratingInt && c.statedoctor == 1).ToList();

                return View(Tuple.Create(filtergendrating1, specialization));


            }
           

            return View(Tuple.Create(alldoctors, specialization));
        }

        public ActionResult AddFeedback(int doctorId, [Bind(Include = "feedbackId,doctorId,patientId,rating,comment,title, statefeedback")] feedback feedback, string ADD,string rating,string title,string yourfeedback)
        {
            string ASPid = User.Identity.GetUserId();
            var Mainid = doc.patients.FirstOrDefault(c => c.Id == ASPid).PatiantId;



            int ratingintfeedback =Convert.ToInt32(rating);

           
            feedback.title= title;
            feedback.comment = yourfeedback;
            feedback.rating = ratingintfeedback;
            feedback.patientId = Mainid;
            feedback.doctorId = doctorId;
            feedback.feedbacktime= DateTime.Now;
            feedback.statefeedback = 0;

            using (var db = new FindingpeaceEntities())
            {
                db.feedbacks.Add(feedback);
                db.SaveChanges();
            }

            //int std = 5;
            //double fill = Convert.ToDouble(db.Students.FirstOrDefault(a => a.Student_ID == std).Wallet);
            //double total = fill + money;
            //db.Students.FirstOrDefault(a => a.Student_ID == std).Wallet = total;
            //db.SaveChanges();
            return RedirectToAction("singledoctor", new { id = doctorId });
        }


        public PartialViewResult _comment(int?id)
        {
            string ASPid = User.Identity.GetUserId();
            var Mainid = doc.patients.FirstOrDefault(c => c.Id == ASPid).PatiantId;
            dynamic model = new ExpandoObject();
            model.feedback = doc.feedbacks.Where(c => c.patientId==Mainid).ToList();
            model.appointment = doc.appointments.Where(c => c.patientId==Mainid).ToList();
            model.doctor = doc.doctors.Where(c => c.doctorId == id).ToList();
         
          
            return PartialView("_comment", model);
        }

     

    public ActionResult singledoctor(int?id)
        {
            string ASPid = User.Identity.GetUserId();
            var Mainid = doc.patients.FirstOrDefault(c => c.Id == ASPid).PatiantId;
            int flag = 0;   
          
            var appointmentexist=doc.appointments.Where(c=>c.doctorId==id&&c.patientId==Mainid).ToList();
            var reapcoment = doc.feedbacks.Where(c => c.doctorId == id && c.patientId == Mainid).ToList();

            int Iscommentexistinfeedback = 0;






            int Isexis = 0;
            foreach (var item in appointmentexist)
            {
                Isexis++;//have apointment ok
            }

            if (Isexis >= 1)
            {
                flag = 1;


            }










            foreach (var item in reapcoment)
            {


                Iscommentexistinfeedback++;





            }

            if(Iscommentexistinfeedback> 0)
            {

                flag = 2;
            }




           


        

            ViewBag.checkit = flag ;


            var SingleDoctor = doc.doctors.Where(c => c.doctorId == id).ToList();
            var feedback = doc.feedbacks.Where(c => c.doctorId == id).ToList();
            if (SingleDoctor != null)
            {
                return View(Tuple.Create(SingleDoctor, feedback));
            }




           














            return RedirectToAction("alldoctors");
        }


        public string GetTimeSinceFeedbackString(TimeSpan timeSinceFeedback)
        {
            if (timeSinceFeedback.TotalDays >= 365)
            {
                int years = (int)(timeSinceFeedback.TotalDays / 365);
                return $"{years} {(years > 1 ? "years" : "year")} ago";
            }
            else if (timeSinceFeedback.TotalDays >= 30)
            {
                int months = (int)(timeSinceFeedback.TotalDays / 30);
                return $"{months} {(months > 1 ? "months" : "month")} ago";
            }
            else if (timeSinceFeedback.TotalDays >= 1)
            {
                int days = (int)timeSinceFeedback.TotalDays;
                return $"{days} {(days > 1 ? "days" : "day")} ago";
            }
            else if (timeSinceFeedback.TotalHours >= 1)
            {
                int hours = (int)timeSinceFeedback.TotalHours;
                return $"{hours} {(hours > 1 ? "hours" : "hour")} ago";
            }
            else if (timeSinceFeedback.TotalMinutes >= 1)
            {
                int minutes = (int)timeSinceFeedback.TotalMinutes;
                return $"{minutes} {(minutes > 1 ? "minutes" : "minute")} ago";
            }
            else
            {
                return "just now";
            }
        }

        public ActionResult doctorprofile()
        {
            

            return View();
        }

        public ActionResult Doctorprof()
        {
            return View();
        }

        public ActionResult booking()
        {
            return View();
        }


        public ActionResult checkout()
        {
            return View();
        }
    }
}