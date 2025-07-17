using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo=new ExperienceRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperiences experience)
        {
            repo.TAdd(experience);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveExperience(int id)
        {
            TblExperiences values=repo.Find(x=>x.Id==id);
            repo.TRemove(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperienceById(int id)
        {
            TblExperiences values = repo.Find(x => x.Id == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult GetExperienceById(TblExperiences entity)
        {
            if (!ModelState.IsValid)
            {
                return View("GetExperienceById");
            }
            TblExperiences values = repo.Find(x => x.Id == entity.Id);
            values.Title = entity.Title;
            values.SubHead = entity.SubHead;
            values.Date = entity.Date;
            values.Description = entity.Description;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}