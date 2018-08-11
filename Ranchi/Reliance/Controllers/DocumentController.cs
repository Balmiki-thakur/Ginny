using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class DocumentController : Controller
    {
        //
        // GET: /Document/

        public ActionResult DocummentMaster(string LinKType)
        {
          //  if (LinKType != null)
           // {
                ViewBag.Id = 6;
            //}

            return View();       
        }

    }
}
