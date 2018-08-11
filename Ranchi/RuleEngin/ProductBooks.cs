using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Rules 
{
    public class ProductBooks
    {
        public ProductBooks(decimal Price)
      {
          this._Price = Price;
         
      }

        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
       
        public static bool IsValueNull(decimal value, string errormsg)
        {
            bool isvalid;
            if (value == null )
            {
                isvalid = false;

            }
            else
            {
                isvalid = true;
                errormsg = "erro";
            }
            return isvalid;
           
        
        }
        
    }
}
