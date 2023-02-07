using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeProj.Models
{
  
        public class Accounts
        {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }
        [ForeignKey("NIK")]
        public virtual Employee Employees { get; set; }
    }

}
