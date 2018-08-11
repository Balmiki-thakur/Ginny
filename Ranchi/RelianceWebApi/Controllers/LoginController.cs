using Reliance.Modals;
using Reliance.Models;
using RelianceController;
using RelianceWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RelianceWebApi.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        //public ActionResult EditUsers(int Id)
        //{
        //    RegistationController EmpRepo = new RegistationController();
        //    RegistationDo registationDo = EmpRepo.UserbyUserId(Id);
        //    return View(registationDo);

        //}
        //[HttpPost]
        //public ActionResult UpdateUsers(RegistationDo registationDo)
        //{

        //    RegistationController EmpRepo = new RegistationController();
        //    EmpRepo.UpdateRegistation(registationDo);//.Single(mem => mem.UserId == Id);
        //    return RedirectToAction("AllUser", "Account");
        //}      
        [Route("AddExternalLogin")]
        [HttpPost]
        public RegistationDo AddExternalLogin(LogOnModel model)
        {
            RegistationDo user = new RegistationDo();
            if (model.UserName != null)
            {
                if (model.Password != null)
                {
                    RegistationController registationController = new RegistationController();
                    // user = RegistationController.UserbyUserId(model.UserName);
                    var LoginType = registationController.UserIdbyPassword(model.UserName, model.Password, model.CompanyName);
                    if (LoginType.Password == model.Password && LoginType.UserName == model.UserName)
                    {
                        return LoginType;
                    }
                }              
            }
            return user;
        }

        [Route("UserAttendance")]
        [HttpPost]
        public string UserAttendance(UserAttendanceDo userandgpsModel)
        {
            string flag = "True";
            int gpsId = 0;
            if (userandgpsModel != null)
            {
                GpsData gps = new GpsData();
                gps.IMIENO = userandgpsModel.IMIENO;
                gps.lattitude = userandgpsModel.lattitude;
                gps.longitude = userandgpsModel.longitude;
                gps.noofSat = userandgpsModel.noofSat;
                gps.rTime = userandgpsModel.rTime;
                gps.cTime = userandgpsModel.cTime;
                gps.angle = userandgpsModel.angle;
                gps.altitude = userandgpsModel.altitude;
                gps.distance = userandgpsModel.distance;
                GPSDataController gpsController = new GPSDataController();
                gpsId= gpsController.InsertGpsdata(gps);

                if (userandgpsModel.Attendanceflag==true)
                {
                     
                        
                }

                return "true";

            }
            else
            {
                return "model is not valid";
            }
        } 
    }
}
