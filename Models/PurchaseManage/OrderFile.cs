using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("OrderFile")]
    [PrimaryKey("ID")]
    public class OrderFile : PurchaseManageDataContext<OrderFile>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public long IDOrder { get; set; }
        [Column]
        public long IDBill { get; set; }
        [Column]
        public string FileName { get; set; }
        [Column]
        public string Path { get; set; }
        [Column]
        public int OrderStatus { get; set; }
        [Column]
        public int Type { get; set; }

    }
}