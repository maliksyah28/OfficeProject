using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Newtonsoft.Json;
namespace OfficeProj.Models
{

        public class Department
        {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Manager_Id { get; set; }
    }
    
}
