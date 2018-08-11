using Reliance.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class MasterUserRegistationController : Controller
    {
        //
        // GET: /MasterUserRegistation/

        public ActionResult DynamicUserRegistation()
        {
            return View();
        }

        //    public ActionResult AddUserRegistation(string formName, FormCollection form)
        //    {

        //        DynamicUserRegistationDoList textList = new DynamicUserRegistationDoList();
        //        foreach (String key in form.AllKeys)
        //        {
        //            DynamicUserRegistationDo textBoxList1 = new DynamicUserRegistationDo();
        //            textBoxList1.FieldId = key;
        //            textBoxList1.Value = form[key];
        //            textList.Add(textBoxList1);
        //            // return View();

        //        }
        //        DynamicUserRegistationDo textBoxList = RelianceController.FormFieldController.InsertMetada(formName, "", textList);

        //        return View();
        //    }
        //}
    }
}
