using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace OfficeProj.Models
{
    public class AccountRoles
    {
        public int Id { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        [ForeignKey("Accounts")]
        public string AccountNIK { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual Accounts Accounts { get; set; }
    }
}
