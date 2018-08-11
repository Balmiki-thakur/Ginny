using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Reliance.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserRegistation()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ContentResult UserRegistation(RegistationDo model)//bool IsAuthantication
         {
             string message = string.Empty;
          if (ModelState.IsValid)
            { 
               var Emailtoken= ConfirmAccount(model);
                bool flag=false;
                RegistationController registationController = new RegistationController();
               flag=  registationController.AddUserRedistation(model);

             if (flag == true)
             {                   
                 return Content("User Insert SucessFully");
             }
             else 
             {
                 return Content("Email Id Is Already Exist");
             }
           }
                    return Content("Error");
            // }
           //  return View();
           // return Json(new { Resut = "ok", Record = registationDo }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (ModelState.IsValid)
            {
                RegistationController RegistationController=new RegistationController();
                RegistationDo registationDo = RegistationController.UserbyUserId(Id);
                return View(registationDo);
            }
            return View();
        }

        [HttpPost]
       public ActionResult AllRegistation()
       { 
            RegistationController registationController = new RegistationController();
            RegistationDoList memberdo = registationController.AllUser();
            return View(memberdo);
        }

        public ActionResult ConfirmAccount(RegistationDo model)
        {
           // var token = WebSecurity.CreateUserAndAccount(model.UserName, model.Password, null, true);
            //return View("ConfirmAccount");
            var confirmationToken = Request["token"];
            if (!String.IsNullOrEmpty(confirmationToken))
            {
                var user = WebSecurity.CurrentUserName;
                WebSecurity.ConfirmAccount(confirmationToken);
                WebSecurity.Login(user, null);
                return View("Welcome");
            }

            TempData["message"] = string.Format(
                        "Your account was not confirmed, please try again or contact the website adminstrator.");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Map()
        {
            return View();
        }
        public ActionResult View1()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }





    }
}
