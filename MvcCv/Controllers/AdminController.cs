using MvcCv.Helper;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminRepository repo=new AdminRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmins admin)
        {
            if (!string.IsNullOrEmpty(admin.Password))
            {
                var aESCipher = new AESCipher("sinankaya");
                admin.Password = aESCipher.Encrypt(admin.Password);
            }
            repo.TAdd(admin);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveAdmin(int id)
        {
            TblAdmins values = repo.Find(x => x.Id == id);
            repo.TRemove(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            TblAdmins values = repo.Find(x => x.Id == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmins entity)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateAdmin");
            }

            if (!string.IsNullOrEmpty(entity.Password))
            {
                var aESCipher = new AESCipher("sinankaya");
                entity.Password = aESCipher.Encrypt(entity.Password);
            }

            TblAdmins values = repo.Find(x => x.Id == entity.Id);
            values.UserName = entity.UserName;
            values.Password = entity.Password;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}