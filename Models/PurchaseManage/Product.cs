using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.PurchaseManage
{
    [TableName("Product")]
    [PrimaryKey("ID")]
    public class Product : PurchaseManageDataContext<Product>
    {
        [Column]
        public int ID { get; set; }
        [Column]
        public int Type { get; set; }
        [Column]
        public int IDChannel { get; set; }
        [Column]
        public string Code { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public int CalUnit { get; set; }
        [Column]
        public string BarCode { get; set; }
        [Column]
        public long Price { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public int CreatedBy { get; set; }
        [Column]
        public DateTime? Updated { get; set; }
        [Column]
        public int UpdatedBy { get; set; }
        [Column]
        public string SearchMeta { get; set; }
        public List<string> FieldSearchs
        {
            get
            {
                return new List<string>
            {
                    "Name","Code","BarCode"
            };
            }
        }
    }
}