using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class DropDownValueDo
   {
       #region private Variable
       private string key = "";
       private string values = "";
       private string formName = "";
       #endregion
       #region Public Variable

       public string Key 
       {
           get
           {
               return this.key;
           }
           set
           {
               this.key = value;
           }
          
       }
       public string Values
       {
           get
           {
               return this.values;
           }
           set 
           {
              this.values=value;
           }
       }
       public string FormName
       {
           get
           {
               return this.formName;
           }
           set
           {
               this.formName = value;
           }
       }
       #endregion
   }
   public class DropDownValueDoList : List<DropDownValueDo>
   {
       public DropDownValueDoList()
       { }
   }
}
