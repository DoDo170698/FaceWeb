using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.CodeLogic.Commons
{
    public class SearchParam
    {
        public string Term { get; set; }
        public int Type { get; set; }
        public int Parent { get; set; }
        public int Status { get; set; }
        public int[] ListStatus { get; set; }
        public string ViewName { get; set; }
        public int[] IDCustomers { get; set; }
        public int[] IDCustomerTypes { get; set; }
        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public DateTime? IRVReturnDateDate { get; set; }
        public DateTime? PayedDate { get; set; }
 
    }
}