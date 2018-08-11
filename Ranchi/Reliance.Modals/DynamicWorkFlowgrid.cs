using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class DynamicWorkFlowgrid
    {
       public string UserName { get; set; }
       public string FormName { get; set; }
       public int Order { get; set; }
       public string Status { get; set; }
       public string Rolename { get; set; }
       public string CreateOn { get; set; }
       public string DocNature { get; set; }
    }
   public class DynamicWorkFlowGridList : List<DynamicWorkFlowgrid>
   {
       public DynamicWorkFlowGridList() 
       { }
   }
}
