using Reliance.Modals;
using Reliance.Models;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;

namespace Reliance.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       

        public HttpWebRequest CreateWebRequest()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://www.w3.org/2003/05/soap-envelope");
            webRequest.Headers.Add(@"SOAP:Action:""http://JKECCPRD.jklc.com:8002/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zgpswebservst/300/zgpswebservst/zgpswebservst?sap-client=300");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            webRequest.PreAuthenticate = true;
            webRequest.Credentials = new NetworkCredential("pirwbuser", "jklc123");

            string certificateName = "name of certificate";
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            certificateName = "name of certificate";
            certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            return webRequest;
        }

     
        public ActionResult AllUser()
        {          
//            HttpWebRequest request = CreateWebRequest();
//            XmlDocument soapEnvelopeXml = new XmlDocument();
//            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
//            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:v1=""http://JKECCPRD.jklc.com:8002"">
//            <soapenv:Header/>
//            <soapenv:Body>
//            <v1:getGreeting/>
//            </soapenv:Body>
//            </soapenv:Envelope>");


//            using (Stream stream = request.GetRequestStream())
//            {
//                soapEnvelopeXml.Save(stream);
//            }

//            using (WebResponse response = request.GetResponse())
//            {
//                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
//                {
//                    string soapResult = rd.ReadToEnd();
//                    // MessageBox.Show(soapResult);
//                }
//            }
            return View();
        }      
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Demo() 
        {
            return View();
        }
        public ActionResult Demo1()
        {
            return View();
        }
        public ActionResult LogOn()
        {

            return View();
        }
   
        public ActionResult EditUser() 
        {
            return View();
        }
        public ActionResult EditUsers(int Id)
        {
            RegistationController EmpRepo = new RegistationController();
            RegistationDo registationDo = EmpRepo.UserbyUserId(Id);
            return View(registationDo);         
        }
        [HttpPost]
        public ActionResult UpdateUsers(RegistationDo registationDo)
        {

            RegistationController EmpRepo = new RegistationController();
            EmpRepo.UpdateRegistation(registationDo);//.Single(mem => mem.UserId == Id);
            return  RedirectToAction( "AllUser", "Account");
        }
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {          
            RegistationDo user = new RegistationDo();
            Session["LOGGED_User"] = user;
            if (model.UserName != null)
            {
                if (model.Password != null)
                {
                    RegistationController registationController = new RegistationController();
                   // user = RegistationController.UserbyUserId(model.UserName);
                    var LoginType = registationController.UserIdbyPassword(model.UserName, model.Password, model.CompanyName);
                    if (LoginType.Password == model.Password && LoginType.UserName == model.UserName)
                    {
                      //FormsAuthentication.SetAuthCookie(LoginType.UserName,false);
                        Session["LOGGED_USER"] = LoginType;
                        Session["LOGGED_User_NAME"] = LoginType.UserName;
                        Session["LOGGED_MEMBER_EMAIL"] = LoginType.Email;
                        Session["LOGGED_UserId"] = LoginType.Userid;
                        Session["LOGGED_ROLE"] = LoginType.Role;
                        Session["LOGGED_Company"] = LoginType.Company;
                        Session["LOGGED_Connectiondb"] = LoginType.Connectiondb;
                        if ( LoginType.UserName == "Shivanks")
                        {
                            return RedirectToAction("DashBoard", "Account");
                        }
                       //  return RedirectToAction("DashboardWorkFlow", "Dashboard", new { area = "Admin" });
                       //  return Redirect("Dashboard/DashboardWorkFlow");
                        return RedirectToAction("DashboardWorkFlow", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }       
            }
            else
            {
                ModelState.AddModelError("", "");
           }
         
            return View();
           
        }

        

        public ActionResult LogOff()
        {
            // FormsAuthentication.SignOut();
              //MemberController.LoggOff();
             //FormsService.SignOut();
            //GLOBAL.LOGGED_MEMBER = null;
            Session["LOGGED_USER"] = null;
            Session["LOGGED_User_NAME"] = null;
            Session["LOGGED_MEMBER_EMAIL"] = null;
            Session["LOGGED_UserId"] = null;
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("LogOn", "Account");
        }
    }
}
