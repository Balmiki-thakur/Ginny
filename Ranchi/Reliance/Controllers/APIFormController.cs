using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Reliance.Controllers
{
    public class APIFormController : ApiController
    {
        public FormRoleList GetItem( string formid, string CompanyId)
        {
            CreateFormField createFormField = new CreateFormField();
            FormRoleList formrole = createFormField.FieldByFormId(formid, CompanyId);
            if (formid != null && CompanyId != null)
            {
                return formrole;
            }
            return formrole;
        }    




    }
}
