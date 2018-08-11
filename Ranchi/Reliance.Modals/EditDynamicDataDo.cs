using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class EditDynamicDataDo
    {
       public string FormId { get; set; }
       public string FieldId { get; set; }
       public string FieldType { get; set; }
       public string FieldName { get; set; }
       public string FieldValue { get; set; }
       public string IsLooKup { get; set; }
       public string DocumentType { get; set; }
       public string DocumentField { get; set; }
       public string DataType { get; set; }
       public string FormName { get; set; }
       public string IsRoleAssignment { get; set; }
       

    }

   public class EditDynamicDataList : List<EditDynamicDataDo>
   {
       public EditDynamicDataList() { }
   }
}
