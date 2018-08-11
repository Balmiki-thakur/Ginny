using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DynamicReport()
        {
            return View();
        }
        public ActionResult MasterDynamicReport()
        {
            return View();
        }



        [HttpPost]
        public JsonResult FinalQuery(string formid, string FieldId, string FormGridId, string Formjoin)
        {
            if (formid != null & FieldId != null & FormGridId != null & Formjoin == null)
            {
                ReportControllers reportControllers = new ReportControllers();
                string query = reportControllers.ReportQuery(formid, FieldId, FormGridId);
                if (query != null)
                {
                    return Json(new { Response = query }, JsonRequestBehavior.AllowGet);
                }


            }
            else 
            {
                ReportControllers reportControllers = new ReportControllers();
              string  data=  reportControllers.ReportJoinQuery(formid, FieldId, FormGridId, Formjoin);
              return Json(new { Response = data }, JsonRequestBehavior.AllowGet);
            
            }
            return Json(new { Response = "" }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult joinQuery(string formid)
        {
            if (formid != null)
            {

                ReportControllers reportControllers = new ReportControllers();
                CreateFormField createFormField = new CreateFormField();
                FormRoleList formrole = createFormField.JoinQuery(formid);

                return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                return Json(new { Response =""}, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
