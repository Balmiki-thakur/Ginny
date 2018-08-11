using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
  public  class FieldValidationDO
    {
        private  string value = "";
        public int id { get; set; }
        public int ValidationType { get; set; }
        public int CompanyId { get; set; }
        public int FormId { get; set; }
        public int FieldId { get; set; }
        public int Operator { get; set; }
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        public string ErrorMsg { get; set; }
        public int DocNature { get; set; }
        public DateTime CreateON = new DateTime(01 / 01 / 1900); 
    }

  public class FieldValidationList : List<FieldValidationDO>
  {
      public FieldValidationList() 
      { }
  
  }
}
