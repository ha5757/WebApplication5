using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class BindingExController : Controller
    {
        // GET: BindingEx
        [ActionName("Example")]
        public ActionResult Sample()
        {
            return View("Sample");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Update(int id)
        {

            return View("Index", DbOperations.GetEmpupdate(id));
        }
        //complex type
        //[HttpPost]
        //public ActionResult Update(EMPDATA E)
        //{
        //    return View();
        //}
        //basic type
        //[HttpPost]
        //public ActionResult Update(int EMPNO,string ENAME,string JOB,int MGR,DateTime HIREDTAE,int SAL,int COMM,int DEPTNO)
        //{
        //    return View();
        //}
        //form collection
        //[HttpPost]
        //public ActionResult Update(FormCollection F)
        //{
        //    int eno = int.Parse(F["EMPNO"]);
        //    string en = F["ENAME"];
        //    return View();
        //}
        [HttpPost]
        public ActionResult Update([Bind(Exclude = "ENAME,JOB,DEPTNO")]  EMPDATA E)
        {
            return View();
        }
    }
}