using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillRepository repo=new SkillRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkills skill)
        {
            repo.TAdd(skill);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveSkill(int id)
        {
            var skill=repo.Find(x=>x.Id==id);
            repo.TRemove(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = repo.Find(x => x.Id == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skill)
        {
            var values = repo.Find(x => x.Id == skill.Id);
            values.Skills = skill.Skills;
            values.Ratio = skill.Ratio;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }   
    }
}