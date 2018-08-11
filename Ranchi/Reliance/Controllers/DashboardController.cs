using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Reliance.Controllers
{ 
  public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult DemoGroup()
        {
            return View();
        }
        public ActionResult DashboardConfigration()
        {
            return View();
        }
        public ActionResult DashboardEcommerce()
        {
            return View();
        }
        public ActionResult DashboardWorkFlow() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult DashboardWorkFlowCount()
        {
            return View();
        }
        public ActionResult InvoiceTicket(string formid, string docid, string Approve, string Reject, string Reconsider, string StatusName,string FormName,string UserName,string CreateOn)
        {
            ViewBag.FormIds = formid;
            ViewBag.docid = docid;
            ViewBag.Approve = Approve;
            ViewBag.Reject = Reject;
            ViewBag.Reconsider = Reconsider;
            ViewBag.StatusName = StatusName;
            ViewBag.UFormName = FormName;
            ViewBag.UserName = UserName;
            ViewBag.CreateOn = CreateOn;
            return View();
        }
        [HttpPost]
        public JsonResult NeedtoAct()
        {
            int Userid = Convert.ToInt32(Session["LOGGED_UserId"]);
           // int RoleId = Convert.ToInt32(Session["LOGGED_ROLE"]);
            NeedToActController needToActController = new NeedToActController();
            NeedToActList needToActList = needToActController.needToAct(Userid);
           return Json(new { Response = needToActList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MyRequest()
        {
            int Userid = Convert.ToInt32(Session["LOGGED_UserId"]);
            NeedToActController needToActController = new NeedToActController();
            NeedToActList MyRequestList = needToActController.MyRequest(Userid);
            return Json(new { Response = MyRequestList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InvoiceTicketData(string formids, string Docid)
        {
           
            RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
            EditDynamicDataList EditDynamicDataList = formFieldController.EditDynamicData(formids, Docid);
            return Json(new { Response = EditDynamicDataList }, JsonRequestBehavior.AllowGet);
           
        }      
        [HttpPost]
        public JsonResult InvoiceTicketAprove(int FormIds, int docid, string StatusName, string UserId)
        {
           //  FormRoleList formrole = CreateFormField.FieldForAproveNeedtoAct(FormIds, StatusName);
             //if (formrole[0].Display_name != null || formrole[0].Display_name =="" )
             //{
               //  return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
             //}
             //else
            //{
            NeedToActController needToActController = new NeedToActController();
            needToActController.needtoactApprove(FormIds, docid, StatusName, UserId);
                 return Json(new { Response = "" }, JsonRequestBehavior.AllowGet);
            //}
        }
        [HttpPost]
        public ActionResult InvoiceTicketReject(int FormIds, int docid, string StatusName,string UserId)
        {
            //FormRoleList formrole = CreateFormField.FieldForRejectNeedtoAct(FormIds, StatusName);
            //if (formrole[0].Display_name != null || formrole[0].Display_name == "")
            //{
            //    return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
            //}
            //else
           // {
            NeedToActController needToActController = new NeedToActController();
            needToActController.needtoactReject(FormIds, docid, StatusName, UserId);
            return RedirectToAction("Dashboard", "DashboardWorkFlow");
           // }
        }
        public JsonResult GPSDataSetting() 
        {
            return Json(new { Response = "" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MapData()
        {
            GpsData gpsdata = new GpsData();
            RelianceController.GPSDataController gPSDataController = new RelianceController.GPSDataController();
             ListGpsData  listgpsData= gPSDataController.AllGPSRecord();
             return Json(new { Response = listgpsData}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Map(int id)
        {
            try
            {
                //using (var db = new ())
                //{

                //    DateTime dateFrom = (id != null && id > 1) ? DateTime.Now.AddDays(-id) : DateTime.Now.AddDays(-1);
                //    List<string> IPAddresses = new List<string>();
                //    IPAddresses = db.IPLogs
                //        .Where(i => i.timeStamp <= DateTime.Now)
                //        .Where(i => i.timeStamp >= dateFrom)
                //        .Select(i => i.IPAddress)
                //        .ToList();
                //    return View(IPAddresses);
                //}
            }
            catch
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public JsonResult InvoiceGridData(int formids, int Docid)
        {             
            NeedToActController needToActController = new NeedToActController();
            NeedToActList needToActList = needToActController.NeedToActGridData(formids, Docid);
            return Json(new { Response = needToActList }, JsonRequestBehavior.AllowGet);

        }
    }
}
