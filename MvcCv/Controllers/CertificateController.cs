using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo=new CertificateRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var values=repo.Find(x=>x.Id==id);
            ViewBag.deletedValue=id;
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(TblCertificates certificate)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCertificate");
            }
            var values = repo.Find(x => x.Id == certificate.Id);
            values.Date= certificate.Date;
            values.Description= certificate.Description;
            repo.TUpdate(values);
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblCertificates certificate)
        {
            repo.TAdd(certificate);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCertificate(int id)
        {
            var values=repo.Find(x=>x.Id==id);
            repo.TRemove(values);
            return RedirectToAction("Index");
        }
    }
}
