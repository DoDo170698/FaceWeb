using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models.Fitness
{
    [TableName("User")]
    [PrimaryKey("ID")]
    public class User : FitnessDataContext<User>
    {
        [Column] public int ID { get; set; }
        //[Column] public int IDRole { get; set; }

        [Column] public string Username { get; set; }

        [Column] public string Password { get; set; }

        [Column] public string Name { get; set; }

        [Column] public DateTime? Birthday { get; set; }

        [Column] public string Phone { get; set; }

        [Column] public string Zalo { get; set; }

        [Column] public string Address { get; set; }

        [Column] public string Email { get; set; }

        [Column] public string PathImg { get; set; }
        [Column] public string FileNameImg { get; set; }

        [Column] public int Status { get; set; }

        [Column] public DateTime Created { get; set; }

        [Column] public int CreatedBy { get; set; }

        [Column] public DateTime? Updated { get; set; }

        [Column] public int? UpdatedBy { get; set; }
        
    }
}