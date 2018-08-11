using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Reliance_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDynamicFormCreate" in both code and config file together.
    [ServiceContract]
    public interface IDynamicFormCreate
    {
        [OperationContract]
        [WebInvoke(Method = "Post", ResponseFormat = WebMessageFormat.Json,  UriTemplate = "/FieldByFormId?formid={formId}")]
        System.IO.Stream FieldByFormId(int formId);
       
    }
}
