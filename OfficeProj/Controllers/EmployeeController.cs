using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeProj.Repositories;
using OfficeProj.ViewModels;
using System.Net;

namespace OfficeProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository repository;
        public EmployeeController(EmployeeRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public virtual ActionResult Get()
        {
            var get = repository.GetAllUserEmployee();
            if (get.Count() != 0)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = get.Count() + " Data Ditemukan", Data = get });
            }
            else
            {
                return StatusCode(200, new { status = HttpStatusCode.NotFound, message = get.Count() + " Data Ditemukan", Data = get });
            }
        }
        [HttpPost]
        public virtual ActionResult Insert(EmployeeVM EmployeeVM)
        {
            var insert = repository.InsertUserEmployee(EmployeeVM);
            if (insert >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Dimasukkan", Data = insert });
            }
            else if (insert == -11)
            {
                return StatusCode(500, new { status = HttpStatusCode.OK, message = "Gagal Memasukkan Data. Username sudah digunakan.", Data = insert });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Memasukkan Data", Data = insert });
            }
        }
    }
}
