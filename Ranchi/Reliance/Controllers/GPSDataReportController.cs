using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Reliance.Controllers
{
    public class GPSDataReportController : Controller
    {
        //
        // GET: /GPSDataReport/

        public ActionResult MPSDataReportCofig()
        {
            return View();
        }

        public ActionResult GPSMileageReport()
        {
            return View();
        }
        public ActionResult GPSMileageGraph()
        {
            return View();
        }
        public ActionResult VehicleTrakingReport() {
           return View();
        }

        public JsonResult VehicleTraking(string Imeino,string StartDataTime, string EndDateTime)
        {
            VehicleTrakingList vehicleTrakingList = VehicleTrakingReportController.VehicleReport(Imeino,StartDataTime, EndDateTime);
            return Json(new { Response = vehicleTrakingList }, JsonRequestBehavior.AllowGet);
        } 

        [HttpPost]
        public JsonResult GPSVehicle(string FormId, string FieldId)
        {            
            RelianceController.FormFieldController formFieldController = new  RelianceController.FormFieldController();
            DropDownValueDoList EditDynamicDataList = formFieldController.DropDownvaluebind(FormId, FieldId);
            return Json(new { Response = EditDynamicDataList }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult mileage_form_submit(string imei_number3, string mstart_date, string mend_date, string mstart_time, string mend_time)
        {
            RelianceController.GPSMileageReportController gPSMileageReportController = new RelianceController.GPSMileageReportController();
            ListMilageGPSDataReport listGpsData = gPSMileageReportController.MilageGPSRecord(imei_number3, mstart_date, mend_date, mstart_time, mend_time);
            return Json(new { Response = listGpsData }, JsonRequestBehavior.AllowGet);   
        }

        [HttpPost]
        public JsonResult GraphDataPlot(string id)
        {
            GpsData gpsdata = new GpsData();
            RelianceController.GPSDataController gPSDataController = new RelianceController.GPSDataController();
            ListGpsData listgpsData = gPSDataController.GrsphGPSRecord();
            return Json(new { Response = listgpsData }, JsonRequestBehavior.AllowGet);
        }
    }
}
