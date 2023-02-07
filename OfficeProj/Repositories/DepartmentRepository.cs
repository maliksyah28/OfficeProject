using OfficeProj.Context;
using OfficeProj.Models;
using OfficeProj.Repositories.Interface;
using OfficeProj.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace OfficeProj.Repositories
{
    public class DepartmentRepository : IRepository<Department,int>
    {
        public IConfiguration _configuration;
        private readonly MyContexts context;
        public DepartmentRepository(IConfiguration configuration, MyContexts context)
        {
            _configuration = configuration;
            this.context = context;
        }
        DynamicParameters parameters = new DynamicParameters();
        public IEnumerable<Department> Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:OfficeProj"]))
            {
                var spName = "SP_DepartmentsGetAll";
                var res = connection.Query<Department>(spName, commandType: CommandType.StoredProcedure);
                return res;
                //throw new System.NotImplementedException();
            }
        }
        public IEnumerable<DepartmentVM> GetDetailDepartment()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:OfficeProj"]))
            {
                var spName = "SP_DepartmentsGetAll";
                var res = connection.Query<DepartmentVM>(spName, commandType: CommandType.StoredProcedure);
                return res;
                //throw new System.NotImplementedException();
            }
        }
        public  int Insert(Department department)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:OfficeProj"]))
            {
                var spName = "SP_DepartmentsInsert";
                parameters.Add("@DepartmentName", department.DepartmentName);
                parameters.Add("@Manager_Id", department.Manager_Id);
                var insert = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }
        public int Update(Department department)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:OfficeProj"]))
            {
                var spName = "SP_DepartmentsUpdate";
                parameters.Add("@Id", department.Id);
                parameters.Add("@DepartmentName", department.DepartmentName);
                parameters.Add("@Manager_Id", department.Manager_Id);
                var update = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
                return update;
            }
        }
        public Department Get(int key)
        {
            throw new NotImplementedException();
        }


       

        public int Delete(int key)
        {
            throw new NotImplementedException();
        }
    }
}
