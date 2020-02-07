using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("Bill")]
    [PrimaryKey("ID")]
    public class Bill : PurchaseManageDataContext<Bill>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public int IDCustomer { get; set; }
        [Column]
        public string Code { get; set; }
        [Column]
        public double Value { get; set; }
        [Column]
        public int Status { get; set; }
        [Column]
        public int Type { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public int CreatedBy { get; set; }
        [Column]
        public DateTime? DeptConfirmDate { get; set; }
        [Column]
        public DateTime? RejectDate { get; set; }
        [Column]
        public DateTime? OwnerConfirmDate { get; set; }
        [Column]
        public string PayedPlace { get; set; }
        [Column]
        public DateTime ? ExpiredDate { get; set; }
   
    }
}