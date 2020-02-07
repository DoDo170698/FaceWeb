using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public int IDChannel { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}