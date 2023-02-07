using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Newtonsoft.Json;

namespace OfficeProj.Models
{
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Manager")]
        public string? Manager_Id { get; set; }
        public virtual Accounts Accounts { get; set; }
        public virtual Employee? Manager { get; set; }
        public virtual List<Employee>? EmployeesManager { get; set; }
        public int Departments_Id { get; set; }
        [ForeignKey("Departments_Id")]
        public virtual Department? Departements { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }

}
