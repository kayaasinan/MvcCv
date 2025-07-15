using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository repo=new AboutRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var value = repo.Find(x => x.Id == p.Id);
            value.Name = p.Name;
            value.SurName = p.SurName;
            value.Address = p.Address;
            value.Phone = p.Phone;
            value.Mail = p.Mail;
            value.Description = p.Description;
            value.Images = p.Images;

            repo.TUpdate(value);
            return RedirectToAction("Index");
        }


    }
}