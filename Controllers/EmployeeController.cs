using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Const;
using EmployeeSalary.Interfaces;
using EmployeeSalary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSalary.Controllers
{
    [Route(ServiceRoutes.Employees)]
    public class EmployeeController : Controller
    {
        private readonly IEmployees employees;
        public EmployeeController(IEmployees _employees)
        {
            employees = _employees ??
                throw new ArgumentNullException(nameof(_employees));
        }

        [HttpGet]
        public Task<IEnumerable<EmployeesResponse>> GetEmployees()
        {
            return employees.GetEmployees();
        }


        [HttpGet("{id}")]
        public Task<EmployeesResponse> GetEmployeesById(int id)
        {
            var emplist = employees.GetEmployees().Result.ToList();
            return Task.FromResult<EmployeesResponse>
                           (emplist.Where(e => e.Id == id).FirstOrDefault());
        }
    }
}