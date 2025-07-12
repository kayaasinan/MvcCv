using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo=new ContactRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
    }
}