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
        GenericRepository<TblSkills> repo=new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
    }
}