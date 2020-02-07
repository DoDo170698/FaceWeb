using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("OrderDiscount")]
    [PrimaryKey("ID")]
    public class OrderDiscount : PurchaseManageDataContext<OrderDiscount>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public int IDCustomer { get; set; }
        [Column]
        public string IDOrders { get; set; }
        [Column]
        public string Code { get; set; }
        [Column]
        public int Type { get; set; }
        [Column]
        public int Quater { get; set; }
        [Column]
        public int Percent { get; set; }
        [Column]
        public int Year { get; set; }
        [Column]
        public long Event { get; set; }
        [Column]
        public long Total { get; set; }
        [Column]
        public long RealTotal { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public int CreatedBy { get; set; }
        [Column]
        public DateTime? Updated { get; set; }
        [Column]
        public int UpdatedBy { get; set; }
        public string SearchMeta { get; set; }
        public List<string> FieldSearchs
        {
            get
            {
                return new List<string>
            {
                   "Code"
            };
            }
        }
    }
}