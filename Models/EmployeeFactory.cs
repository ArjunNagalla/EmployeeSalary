using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalary.Abstract;
using EmployeeSalary.Interfaces;

namespace EmployeeSalary.Models
{
    public class EmployeeFactory : EmployeeAbstractFactory
    {
        public override IEmployeeContract GetContractType(string employeeContractType)
        {
            //object typeOfEmployee = new object();
            //if (employeeList != null)
            //{
            //    foreach (EmployeesResponse emp in employeeList)
            //    {
                    switch (employeeContractType)
                    {
                        case "HourlySalaryEmployee":
                            return new EmployeeHourlySalary();
                        case "MonthlySalaryEmployee":
                            return new EmployeeMonthlySalary();
                        default:
                            throw new ApplicationException(string.Format("Employee contract type '{0}' is not valid", employeeContractType));
                    }
            //    };
            //}
            //return typeOfEmployee;
        }
    }
}
