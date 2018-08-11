using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class DefultController : Controller
    {
        //
        // GET: /Defult/

        public ActionResult DefultForm()
        {
            return View();
        }

        public ActionResult ChildForm() 
        {
            return PartialView();
        }
        public ActionResult DocumentForm()
        {
            return PartialView();
        }


      
              
        //public JsonResult AllFormList()
        //{
        //    RelianceController.CreateFormMaster createFormMaster = new RelianceController.CreateFormMaster();
        //    CreateTableDoList createTableDoList = createFormMaster.AllCreateForm();

        //    return Json(new { Response = createTableDoList }, JsonRequestBehavior.AllowGet);
        //}
    }
}
