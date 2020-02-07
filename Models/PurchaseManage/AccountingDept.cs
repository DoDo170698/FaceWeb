using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("AccountingDept")]
    [PrimaryKey("ID")]
    public class AccountingDept : PurchaseManageDataContext<AccountingDept>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public int IDOrder { get; set; }
        [Column]
        public int Status { get; set; }
        [Column]
        public int Type { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public int CreatedBy { get; set; }
        [Column]
        public DateTime? ConfirmDate { get; set; }
        [Column]
        public DateTime? RejectDate { get; set; }
    }
}