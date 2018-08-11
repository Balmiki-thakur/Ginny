using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Reliance.Controllers
{
    public class DynamicWorkFlowController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddDymanicworkflow(DynamicWorkFlowDo dynamicWorkFlowDoList)
        {
            NeedToActController needToActController = new NeedToActController();
            needToActController.AddMasterMoveMent(dynamicWorkFlowDoList);
            return Json(new { Responses ="add"}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Dymanicworkflowfield(string formid)
        {
            RelianceController.FieldPropertyController fieldPropertyController = new RelianceController.FieldPropertyController();
            FIeldPropertyList fIeldPropertyList = fieldPropertyController.FieldByFormIdworkflow(formid);
            return Json(new { Response = fIeldPropertyList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DynamicWorkFlowformid(string formId)
        {
            WorkFlowStatusControllers workFlowStatusControllers= new WorkFlowStatusControllers();
            DynamicWorkFlowGridList dynamicWorkFlowGridList = workFlowStatusControllers.DynamicWorkFlowformId(formId);
            return Json(new { Response = dynamicWorkFlowGridList }, JsonRequestBehavior.AllowGet);
        }
    }
}
