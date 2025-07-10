using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.TblExperiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Education()
        {
            var educations = db.TblEducation.ToList();
            return PartialView(educations);
        }
        public PartialViewResult Skill()
        {
            var skills = db.TblSkills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Interest()
        {
            var interests = db.TblInterests.ToList();
            return PartialView(interests);
        }
        public PartialViewResult Certificate()
        {
            var certificates = db.TblCertificates.ToList();
            return PartialView(certificates);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblContacts t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContacts.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}