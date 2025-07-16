using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbCvEntities db = new DbCvEntities();
        [HttpGet]
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmins admin)
        {
            var loginInfo = db.TblAdmins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (loginInfo != null)
            {
                FormsAuthentication.SetAuthCookie(loginInfo.UserName, false);
                Session["UserName"] = loginInfo.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                TempData["LoginError"] = "Kullanıcı adı veya şifre hatalı, lütfen tekrar deneyin.";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}