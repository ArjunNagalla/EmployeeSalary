﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSalary.Models
{
    public class EmployeesResponse
    {
        public int Id;
        public string Name;
        public string ContractTypeName;
        public int RoleId;
        public string RoleName;
        public string RoleDescription;
        public decimal HourlySalary;
        public decimal MonthlySalary;
        public decimal AnnualSalary;
    }
}
