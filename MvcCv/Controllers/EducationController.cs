using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo=new EducationRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation education)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(education);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveEducation(int id)
        {
            var values=repo.Find(x=>x.Id==id);
            repo.TRemove(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values = repo.Find(x => x.Id == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation education)
        {

            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var values = repo.Find(x => x.Id == education.Id);
            values.Title = education.Title;
            values.SubHead1 = education.SubHead1;
            values.SubHead2 = education.SubHead2;
            values.GPA = education.GPA;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}