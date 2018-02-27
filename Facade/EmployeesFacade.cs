using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeSalary.Interfaces;
using EmployeeSalary.Models;
using Newtonsoft.Json;

namespace EmployeeSalary.Facade
{
    public class EmployeesFacade : IEmployees
    {
        private readonly IProcessEmployeeDetails _processEmployeeDetails;
        public EmployeesFacade(IProcessEmployeeDetails processEmployeeDetails)
        {
            _processEmployeeDetails = processEmployeeDetails;
        }
        public async Task<IEnumerable<EmployeesResponse>> GetEmployees()
        {
            return await _processEmployeeDetails.GetEmployees();
        }
    }
}
