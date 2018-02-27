using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Interfaces;

namespace EmployeeSalary.Models
{
    public class EmployeeHourlySalary : IEmployeeContract
    {
        public decimal CalculateAnnualSalary(decimal hourlySalary)
        {
            return 120 * 12 * hourlySalary;
        }
    }
}
