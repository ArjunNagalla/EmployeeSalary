using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Interfaces;

namespace EmployeeSalary.Models
{
    public class EmployeeMonthlySalary : IEmployeeContract
    {
        public decimal CalculateAnnualSalary(decimal monthlySalary)
        {
            return monthlySalary * 12;
        }
    }
}
