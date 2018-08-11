using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class RoleAssignmentController : Controller
    {
        //
        // GET: /RoleAssignment/

        public ActionResult RoleAssignment()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RoleByUser(int RoleId)
        {
            
                RegistationController RegistationController = new RegistationController();
                RegistationDoList registationDo = RegistationController.RolebyUserId(RoleId);
                return Json(new { Responses = registationDo }, JsonRequestBehavior.AllowGet);      
        }

        [HttpPost]
        public JsonResult AddRoleAssigment(IsROleAssignmentDo isroleAssignmentDo)
        {           
             IsRoleAssignmentController isRoleAssignmentController= new IsRoleAssignmentController();
                           isRoleAssignmentController.AddRoleAssingment(isroleAssignmentDo);
            return Json(new { Responses = isroleAssignmentDo }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AllFormListWithRoleAssingment(string CompanyId)
        {
            RelianceController.IsRoleAssignmentController isRoleAssignmentController = new RelianceController.IsRoleAssignmentController();
            AllFormRoleAssingmentList allFormRoleAssingmentList = isRoleAssignmentController.AllFormRoleAssingment(CompanyId);
            return Json(new { Response = allFormRoleAssingmentList }, JsonRequestBehavior.AllowGet);
        }
    }
}
