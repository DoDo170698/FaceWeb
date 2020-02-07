using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.Fitness
{
    [TableName("UserRole")]
    [PrimaryKey("ID")]
    public class UserRole : FitnessDataContext<UserRole>
    {
        [Column] public int ID { get; set; }

        [Column] public int IDUser { get; set; }

        [Column] public int IDRole { get; set; }

        [Column] public DateTime Created { get; set; }

        [Column] public int CreatedBy { get; set; }

        [Column] public DateTime? Updated { get; set; }

        [Column] public int? UpdatedBy { get; set; }
    }
}