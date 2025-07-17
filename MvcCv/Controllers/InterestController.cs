using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        InterestRepository repo = new InterestRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateInterest(int id)
        {
            var values = repo.Find(x => x.Id == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateInterest(TblInterests interest)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateInterest");
            }
            var values = repo.Find(x => x.Id == interest.Id);
            values.Description1 = interest.Description1;
            values.Description2 = interest.Description2;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}