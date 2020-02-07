using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("CustomerTypeProduct")]
    [PrimaryKey("ID")]
    public class CustomerTypeProduct : PurchaseManageDataContext<CustomerTypeProduct>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public int IDCustomerType { get; set; }
        [Column]
        public int IDProduct { get; set; }
        [Column]
        public double Price { get; set; }
    }
}