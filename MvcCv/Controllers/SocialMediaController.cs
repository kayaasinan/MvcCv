using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository repo=new SocialMediaRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia media)
        {
            repo.TAdd(media);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = repo.Find(x=>x.Id==id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia media)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateSocialMedia");
            }
            var values = repo.Find(x=>x.Id==media.Id);
            values.SMName=media.SMName;
            values.SMLink=media.SMLink;
            values.SMIcon=media.SMIcon;
            values.Status=true;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveSocialMedia(int id)
        {
            var values=repo.Find(x=>x.Id==id);
            values.Status=false;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}