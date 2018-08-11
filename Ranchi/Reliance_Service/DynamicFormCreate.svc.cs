using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;

namespace Reliance_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DynamicFormCreate" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DynamicFormCreate.svc or DynamicFormCreate.svc.cs at the Solution Explorer and start debugging.
    public class DynamicFormCreate : IDynamicFormCreate
    {
        public Stream FieldByFormId(int formId)
        {
            throw new NotImplementedException();
        }

        public  FormsFields GetFormByFormId(string formId)
        {
            FormsFields formsFields = FormFieldController.FieldByFormId(Convert.ToInt32(formId));      
         OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
           context.ContentType = "application/json";
          JavaScriptSerializer serializer = new JavaScriptSerializer();
          return formsFields;

        }
    }
}
