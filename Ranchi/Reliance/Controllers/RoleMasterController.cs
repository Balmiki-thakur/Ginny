using Reliance.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class RoleMasterController : Controller
    {
        //
        // GET: /RoleMaster/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RoleMaster()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RoleItems(string rolename, string roleDescription, string CompanyId)
        {
            RoleMasterDo rolemaster = new RoleMasterDo();
            rolemaster.RoleName = rolename;
            rolemaster.RoleDescription = roleDescription;
            rolemaster.CompanyId = Convert.ToInt32(CompanyId);
            RelianceController.RoleMasterController  roleMasterController= new RelianceController.RoleMasterController();
            roleMasterController.AddRoleItems(rolemaster);
            return Json(new { Response = rolemaster }, JsonRequestBehavior.AllowGet);
        }

       
       // [HttpPost]
        public ActionResult EditRole(string Id)
        {
            RelianceController.RoleMasterController roleMasterController = new RelianceController.RoleMasterController();
            RoleMasterDo roleMasterDo = roleMasterController.RolebyRoleId(Id);
            return View(roleMasterDo);
        }
        //[HttpPost]
        //public ActionResult UpdateRole(RegistationDo registationDo)
        //{

        //    RegistationController EmpRepo = new RegistationController();
        //    EmpRepo.UpdateRegistation(registationDo);//.Single(mem => mem.UserId == Id);
        //    return RedirectToAction("AllUser", "Account");
        //}

    }
}
