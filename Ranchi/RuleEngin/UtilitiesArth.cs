using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Rules
{

    public class UtilitiesArthematic
    {

        public decimal CalculateTotal(List<MyItem> items)
        {
            decimal total = 0.0M;
            foreach (MyItem i in items)
            {
                total += i.UnitPrice * (1 - i.Discount);
            }
            return total;
        }
    }
    public class MyItem
    {
        public MyItem(decimal unitPrice)
        {
            _unitPrice = unitPrice;
        }

        public MyItem(decimal unitPrice, decimal discount)
            : this(unitPrice)
        {
            _discount = discount;
        }

        private decimal _unitPrice;
        private decimal _discount;

        public decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
    }
}
