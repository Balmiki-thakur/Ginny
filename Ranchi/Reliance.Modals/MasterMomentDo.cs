using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class MasterMomentDo
    {
       public int Id { get; set; }
       public int docid { get; set; }
       public int Formid { get; set; }
       public int UserId { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime UpdateDate { get; set; }
       public string FormName { get; set; }
       public long FormCount { get; set; }
    }
   public class MasterMomentList : List<MasterMomentDo>
   {
       public MasterMomentList()
       { }
   }
}
