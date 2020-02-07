using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("OrderHistory")]
    [PrimaryKey("ID")]
    public class OrderHistory : PurchaseManageDataContext<OrderHistory>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public int IDOrder { get; set; }
        [Column]
        public int OrderStatus { get; set; }
        [Column]
        public int Action { get; set; } 
        [Column]
        public DateTime? Date { get; set; }
    }
}