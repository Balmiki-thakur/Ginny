using Reliance.Modals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Reliance.Controllers
{
    public class MenuMasterController : Controller
    {
        //
        // GET: /MenuMaster/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        [HttpPost]
        public JsonResult MenuItems(string menuname, string menuDescription, string MenuOrder, string Image,string  CompanyId)
        {
            MenuMasterDo menuitem = new MenuMasterDo();
            menuitem.Menuname = menuname;
            menuitem.MenuDescription = menuDescription;
            menuitem.MenuOrder = Convert.ToInt32(MenuOrder);
            menuitem.Image = Image;
            menuitem.Eid = Convert.ToInt32(CompanyId);
            RelianceController.MenuMasterController menuMasterController = new RelianceController.MenuMasterController();
            menuMasterController.AddMenuItems(menuitem);
            return Json(new { Response = menuitem }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SubMenuItems(string parentmenu, string pagelinktype, string pagelink, string SubMenuName, string SubMenuOrder, string SubMenuImage, string CompanyId)
        {

            MenuMasterDo menuitem = new MenuMasterDo();
            menuitem.PMenu = Convert.ToInt64(parentmenu);
            menuitem.Menutype = pagelinktype;
            menuitem.MenuLink = pagelink;
            menuitem.Menuname = SubMenuName;
            menuitem.MenuOrder = Convert.ToInt32(SubMenuOrder);
            menuitem.Image = SubMenuImage;
            menuitem.Eid = Convert.ToInt32(CompanyId);
            RelianceController.MenuMasterController menuMasterController = new RelianceController.MenuMasterController();
            menuMasterController.AddSubMenuItems(menuitem);
            return Json(new { Response = menuitem }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MenuRole()
        {
            return Json(new { Response }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ArrayHandler(MenuRoleDoList roles)
        {
            RelianceController.MenuMasterController menuMasterController = new RelianceController.MenuMasterController();
            menuMasterController.InsertRole(roles);

            return View("Role Insert Successfully");
        }

        public JsonResult MenuEdit(string Id)
        {
           RelianceController.MenuMasterController menuMasterController= new RelianceController.MenuMasterController();
           MenuMasterDo EditDynamicDataList = menuMasterController.EditMenuByMenuId(Id);
            return Json(new { Response = EditDynamicDataList }, JsonRequestBehavior.AllowGet);
            // var data = FormFieldController.GetCategory();     
        }
        public JsonResult MenuRole(string Id)
        {
            RelianceController.MenuRoleController menuRoleController= new RelianceController.MenuRoleController();
            MenuRoleDoList menuRoleDoList = menuRoleController.MenuRoleByMenuId(Id);
            return Json(new { Response = menuRoleDoList }, JsonRequestBehavior.AllowGet);
            // var data = FormFieldController.GetCategory();     
        }

        //[HttpPost]
        //public JsonResult EditSubMenuItems(string id, string parentmenu, string pagelinktype, string pagelink, string SubMenuName, string SubMenuOrder, string SubMenuImage)
        //{

        //    MenuMasterDo menuitem = new MenuMasterDo();
        //    menuitem.MenunId = Convert.ToInt64(id);
        //    menuitem.PMenu = Convert.ToInt64(parentmenu);
        //    menuitem.Menutype = pagelinktype;
        //    menuitem.MenuLink = pagelink;
        //    menuitem.Menuname = SubMenuName;
        //    menuitem.MenuOrder = Convert.ToInt32(SubMenuOrder);
        //    menuitem.Image = SubMenuImage;
        //    RelianceController.MenuMasterController.UpdateSubMenuItems(menuitem);
        //    return Json(new { Response = menuitem }, JsonRequestBehavior.AllowGet);
        //}

    }
}