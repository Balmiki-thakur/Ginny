using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class WorkFlowStatusController : Controller
    {
        //
        // GET: /WorkFlowStatus/

        public ActionResult Index()
        {
            return View();
        }

        public ContentResult WorkFlow()
        {
            return Content("Shivank");
        }
        public ActionResult WorkFolwStatus()
        {
            return View();
        }
        public ActionResult DynamicWorkFlow()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddWorkFlowStatuss(WorkFlowStatusDo workFlowStatusDo)
        {
            WorkFlowStatusControllers workFlowStatusControllers = new WorkFlowStatusControllers();
            workFlowStatusControllers.AddworkFlowStatus(workFlowStatusDo);
            return Json(new { Response = "Add SuccessFully" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult WorkFlowStatusbyformid(string formId)
        {
            WorkFlowStatusControllers workFlowStatusControllers = new WorkFlowStatusControllers();
            WorkFlowList workflowlist = workFlowStatusControllers.StatusbyformId(formId);
            return Json(new { Response = workflowlist }, JsonRequestBehavior.AllowGet);
        }
    }
}
