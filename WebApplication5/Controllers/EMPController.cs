using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EMPController : Controller
    {
        // GET: EMP
        public ActionResult Index()
        {
            List<EMPDATA> L = DbOperations.GetAll();
            return View(L);
        }
        public ActionResult Create()
        {
            EMPDATA E = new EMPDATA();
            return View(E);
        }
        [HttpPost]
        public ActionResult Create(EMPDATA E)
        {
            ViewBag.msg = DbOperations.InsertEmp(E);
            return View();
        }
        public ActionResult Edit(int id)
        {
            EMPDATA E = DbOperations.GetEmpupdate(id);
            return View(E);
        }
        public ActionResult Update(EMPDATA E)
        {

           
            string m = DbOperations.GetEmpnoData(E);
            ViewBag.res = m;
            return View();
        }
        public ActionResult Delete(int id)
        {
            ViewBag.msg = DbOperations.DeleteEmp(id);
            return View();
        }
    }
}