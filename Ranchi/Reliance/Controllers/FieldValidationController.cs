using Reliance.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class FieldValidationController : Controller
    {
        //
        // GET: /FieldValidation/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Validaton(FieldValidationDO fieldvalidationDO) 
        {
            RelianceController.FormValidationController formValidationController = new RelianceController.FormValidationController();
            formValidationController.AddFieldValidation(fieldvalidationDO);
            return Json(new { OnSuccess = "success" }, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public JsonResult ValidationByFormId(string formid)
        //{
        //    RelianceController.FormValidationController formValidationController =new RelianceController.FormValidationController
        // // FieldValidationList fieldValidationbyformid = formValidationController.FormvalidationbyFormid(formid);
        //    return Json(new { Response = fieldValidationbyformid }, JsonRequestBehavior.AllowGet);
        //}

    }
}
