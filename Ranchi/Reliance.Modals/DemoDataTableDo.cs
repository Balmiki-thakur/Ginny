using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class DemoDataTableDo
    {
       
        public string fld1{get;set;}
        public string fld10{get;set;}
        public string fld14{get;set;}
    }
    public class DemoDataTableDoList:List<DemoDataTableDo>
    {
       public DemoDataTableDoList()
       { }
    }
}
