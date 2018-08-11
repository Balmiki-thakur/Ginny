using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class NeedToActDo
    {
       public int DocId { get; set; }
       public string FormName { get; set; }
       public string UFormName { get; set; }
       public string UserName { get; set; }
       public string StatusName { get; set; }
       public string CreateOn { get; set; }
       public string PendingTime { get; set; }
       public int FormId { get; set; }
       public string Approve { get; set; }
       public string Reject { get; set; }
       public string Reconisider { get; set; }
    }
   public class NeedToActList : List<NeedToActDo>
   {
       public NeedToActList() { }
   }
}
