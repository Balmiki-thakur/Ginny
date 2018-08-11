using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Reliance_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "test" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select test.svc or test.svc.cs at the Solution Explorer and start debugging.
    public  class test : Itest
    {
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public FormsFields DoWork(int formId)
        {
            FormsFields formsFields = FormFieldController.FieldByFormId(Convert.ToInt32(formId));
            return formsFields;
        }
    }
}
