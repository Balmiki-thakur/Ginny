using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class FieldPropertysController : Controller
    {
        //
        // GET: /FieldPropertys/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  JsonResult AddFieldPropertys(FieldPropertyDo fieldProperty) 
        {
            FieldPropertyController fieldPropertyController = new FieldPropertyController();
            fieldPropertyController.AddFormField(fieldProperty);
            return Json(new { Response =  ""}, JsonRequestBehavior.AllowGet);
        }
    }
}
