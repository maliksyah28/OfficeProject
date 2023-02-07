using OfficeProj.Context;
using OfficeProj.Models;
using OfficeProj.Repositories.Interface;
using OfficeProj.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace OfficeProj.Repositories
{
    public class EmployeeRepository : IRepository<Employee, string>
    {
        public IConfiguration _configuration;
        private readonly MyContexts context;
        public EmployeeRepository(IConfiguration configuration, MyContexts context)
        {
            _configuration = configuration;
            this.context = context;
        }
        DynamicParameters parameters = new DynamicParameters();
        public virtual IEnumerable<EmployeeVM> GetAllUserEmployee()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:OfficeProj"]))
            {
                var spName = "SP_EmployeeGetAll";
                var res = connection.Query<EmployeeVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        public virtual int InsertUserEmployee(EmployeeVM EmployeeVM)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:OfficeProj"]))
            {
                string generatedNIK = GenerateNIK();
             
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(EmployeeVM.Password);

                var spName = "SP_EmployeeInsert";
                parameters = new DynamicParameters();
                parameters.Add("@NIK", generatedNIK);
                parameters.Add("@FirstName", EmployeeVM.FirstName);
                parameters.Add("@LastName", EmployeeVM.LastName);
                parameters.Add("@Phone", EmployeeVM.Phone);
                parameters.Add("@BirthDate", EmployeeVM.BirthDate);
                parameters.Add("@Salary", EmployeeVM.Salary);
                parameters.Add("@Email", EmployeeVM.Email);
                parameters.Add("@Gender", EmployeeVM.Gender);
                parameters.Add("@Manager_Id", EmployeeVM.Manager_Id);
                parameters.Add("@Departments_Id", EmployeeVM.Departments_Id);
                parameters.Add("@Password", passwordHash);
                parameters.Add("@RoleId", EmployeeVM.RoleId);
                //parameters.Add("@RoleName", EmployeeVM.RoleName);
                //parameters.Add("@DepartmentName", EmployeeVM.DepartmentName);
                var insert = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }
        private string GenerateNIK()
        {
            var lastId = context.Employees.FromSqlRaw(
                "SELECT TOP 1 * " +
                "FROM Employees " +
                "WHERE len(NIK) = 12 " +
                "ORDER BY RIGHT(NIK, 4) desc"
                ).ToList();
            int highestId = 0;
            if (lastId.Any())
            {
                var newId = lastId[0].NIK;
                newId = newId.Substring(newId.Length - 4);
                highestId = Convert.ToInt32(newId);
            }

            int increamentId = highestId + 1;
            string generatedNIK = increamentId.ToString().PadLeft(4, '0');
            DateTime today = DateTime.Today;
            var dateNow = today.ToString("yyyyddMM");
            generatedNIK = dateNow + generatedNIK;

            return generatedNIK;
        }
        public int Delete(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee Get(string key)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
