using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("Order")]
    [PrimaryKey("ID")]
    public class Order : PurchaseManageDataContext<Order>
    {
        [Column]
        public long ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public int IDCustomer { get; set; }
        [Column]
        public int IDSupplier { get; set; }
        [Column]
        public long IDBill { get; set; }
        [Column]
        public string PONo { get; set; }
        [Column]
        public DateTime ? PODate { get; set; }
        [Column]
        public string Purchaser { get; set; }
        [Column]
        public DateTime? DeliveryDate { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Tel { get; set; }
        [Column]
        public string Note { get; set; }
        [Column]
        public int Status { get; set; }
        [Column]
        public long Value { get; set; }
        [Column]
        public long RealValue { get; set; }
        public string Address { get; set; }
        [Column] 
        public int Type { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public int CreatedBy { get; set; }
        [Column]
        public DateTime? Updated { get; set; }
        [Column]
        public int UpdatedBy { get; set; }
        [Column]
        public DateTime? CollectedDate { get; set; }
        [Column]
        public DateTime? AccountingDeptDate { get; set; }
        [Column]
        public DateTime? PayedDate { get; set; }
        [Column]
        public DateTime? IRVReturnDate { get; set; }
        [Column]
        public DateTime? RealDeliveryDate { get; set; }

        [Column]
        public DateTime? AccountingDeptConfirmDate { get; set; }
        [Column]
        public DateTime? AccountingDeptRejectDate { get; set; }
        [Column]
        public DateTime? PayedConfirmDate{ get; set; }
        [Column]
        public string PayedPlace { get; set; }
        [Column]
        public long Parent { get; set; }
        [Column]
        public bool IsGroup { get; set; }
        [Column]
        public string SearchMeta { get; set; }
        public List<string> FieldSearchs
        {
            get
            {
                return new List<string>
            {
                    "PONo","Note"
            };
            }
        }
    }
}