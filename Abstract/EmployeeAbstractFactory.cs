using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Interfaces;
using EmployeeSalary.Models;

namespace EmployeeSalary.Abstract
{
    public abstract class EmployeeAbstractFactory
    {
        public abstract IEmployeeContract GetContractType(string employeeContractType);
    }
}
