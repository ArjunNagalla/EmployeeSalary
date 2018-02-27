using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Models;

namespace EmployeeSalary.Interfaces
{
    public interface IProcessEmployeeDetails
    {
        Task<IEnumerable<EmployeesResponse>> GetEmployees();
    }
}
