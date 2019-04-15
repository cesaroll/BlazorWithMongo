using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithMongo.Server.DataAccess;
using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWithMongo.Server.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private EmployeeDataAccessLayer EmployeeDAL { get; } = new EmployeeDataAccessLayer();

        // GET api/Employee/Index
        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index()
        {
            return EmployeeDAL.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public void Create([FromBody] Employee emp)
        {
            EmployeeDAL.AddEmployee(emp);

        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(string id)
        {
            return EmployeeDAL.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public void Edit([FromBody] Employee emp)
        {
            EmployeeDAL.updateEmployee(emp);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public void Delete(string id)
        {
            EmployeeDAL.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/Employee/Cities")]
        public List<City> Cities()
        {
            return EmployeeDAL.GetAllCities();
        }

    }
}
