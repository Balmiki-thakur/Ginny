using Reliance.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class RuleEnginController : Controller
    {
        //
        // GET: /RuleEngin/
        public ActionResult Rule()
        {
            return View();
        }
        public ActionResult RuleReport()
        {
            return View();
        }
         [HttpPost]
        public ActionResult RuleInsert(RuleEnginDo ruleEnginDo)
        {
            RelianceController.RuleEnginController ruleEnginController = new RelianceController.RuleEnginController();
            ruleEnginController.AddRuleEngin(ruleEnginDo);
            return View();
        }      
        public ActionResult RuleList(string formid)
         {
             RuleEnginDoList rule = RelianceController.RuleEnginController.RuleByFormId(formid);
             return Json(new { Response = rule }, JsonRequestBehavior.AllowGet);
         }
        public ActionResult FormulaRule()
        {
            return PartialView();
        }
        public ActionResult CheckFieldValue(string CurrentFeildValue, string ConditionField ,string Conditionid,string RuleFieldName)
        {
            var flag = RelianceController.RuleEnginController.RuleConditonCheck(CurrentFeildValue, ConditionField, Conditionid, RuleFieldName);

            return Json(new { Resp = flag }, JsonRequestBehavior.AllowGet);
        }
    }
}
