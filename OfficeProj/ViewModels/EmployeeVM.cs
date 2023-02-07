using OfficeProj.Models;

namespace OfficeProj.ViewModels
{
    public class EmployeeVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Salary { get; set; }
        public string? Email { get; set; }
        public Gender? Gender { get; set; }
        public int? Departments_Id { get; set; }    
        public string? Manager_Id { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? DepartmentName { get; set; }
       
    }
}
