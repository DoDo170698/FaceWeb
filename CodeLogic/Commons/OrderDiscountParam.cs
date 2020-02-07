using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.CodeLogic.Commons
{
    public class BillDiscountParam : SearchParam
    {
        public int IDCustomer { get; set; }
        public int Quater { get; set; }
        public int Year { get; set; }
        public long[] IDS { get; set; }
    }
}