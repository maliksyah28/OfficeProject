using OfficeProj.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace OfficeProj.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
