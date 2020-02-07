using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("BillDiscount")]
    [PrimaryKey("ID")]
    public class BillDiscount : PurchaseManageDataContext<BillDiscount>
    {
        [Column]
        public long ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public long IDBill { get; set; }
        [Column]
        public int Percent { get; set; }
        [Column]
        public double Event { get; set; }
        [Column]
        public double Total { get; set; }
        [Column]
        public double RealTotal { get; set; }
        [Column]
        public DateTime? StartDate { get; set; }
        [Column]
        public DateTime? EndDate { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public int CreatedBy { get; set; }
        [Column]
        public DateTime? Updated { get; set; }
        [Column]
        public int UpdatedBy { get; set; }
        [Column]
        public double DiscountTotal { get; set; } 
        [Column]
        public string Describe { get; set; }
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