using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class FieldPropertyDo
   {
          public int FormId { get; set; }
          public int FieldId { get; set; }
          public bool MANDATORY	  {get; set;}
          public bool ACTIVE { get; set; }
          public bool EDITABLE { get; set; }
          public bool WORKFLOW { get; set; }
          public bool UNIQUE { get; set; }
          public bool SHOWONAMENDMENT { get; set; }
          public bool SEARCH { get; set; }
          public bool EDITONAMENDMENT { get; set; }
          public bool IMIENo { get; set; }
          public bool PHONENo { get; set; }
          public bool INLINEEDITING { get; set; }
          public bool SHOWONDOCDETAIL { get; set; }
          public bool Invisible { get; set; }
          public bool SPLITTABLE { get; set; }
          public bool SHOWONSPLIT { get; set; }
          public bool ISSUPERVISOR { get; set; }
          public bool EnableEdit { get; set; }
          public bool PriorityDecider { get; set; }
          public bool CRMReminder { get; set; }
          public bool ShowOnDeshboard { get; set; }
          public bool ShowOnCRM { get; set; }
          public bool EDITOnCRM { get; set; }
          public bool IsTotal { get; set; }
          public bool AllowEditOnEdit { get; set; }
          public bool ExternalLookupForMobile { get; set; }
          public bool ShowInRoleAssignment { get; set; }
          public bool IsCardNo { get; set; }
          public bool ReportName { get; set; }
          public bool PlaceofStay { get; set; }
          public bool PopupNotificationFieldonMobile { get; set; }
          public bool ActionFormField { get; set; }
         
    }

    public class FIeldPropertyList:List<FieldPropertyDo>
    {
        public FIeldPropertyList() { }
    }
}
