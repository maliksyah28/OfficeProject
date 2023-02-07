using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Newtonsoft.Json;
namespace OfficeProj.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string NameRoles { get; set; }  
    }
}
