using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.CodeLogic.Commons
{
    public class AccountingDeptParam : SearchParam
    {
        public int IDOrder { get; set; }
        public int IDOrders { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int OrderType { get; set; }
        public DateTime ? ConfirmDate { get; set; }
        public DateTime? RejectDate { get; set; }
    }
}