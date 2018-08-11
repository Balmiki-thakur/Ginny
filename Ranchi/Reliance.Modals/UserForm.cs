using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
     public class UserForm
    {
         public int Id { get; set;}
         public string Name { get; set; }
         public IList<UserInterest> Interests { get; set; }
    }
     public class UserInterest 
     {
         public int Id { get; set; }
         public string IntrestText { get; set;}
        // public bool IsExprience { get; set; }
     }
}
