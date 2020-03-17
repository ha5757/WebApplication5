using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            
            return View();
        }
        public ActionResult profile(tbl_login b)
        {
            if(ModelState.IsValid)
            {
                string um = Request.Form["username"];
                string pw = Request.Form["password"];
                if(DbOperations.get(um,pw))
                {
                   return RedirectToAction("Index", "Home");
                }
               else
                {
                    return View("LoginPage");
                }
            }
            return View("LoginPage");
        }
    }
}