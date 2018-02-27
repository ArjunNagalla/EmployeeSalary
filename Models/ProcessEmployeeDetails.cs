using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeSalary.Abstract;
using EmployeeSalary.Interfaces;
using Newtonsoft.Json;

namespace EmployeeSalary.Models
{
    public class ProcessEmployeeDetails : IProcessEmployeeDetails
    {
        public Task<IEnumerable<EmployeesResponse>> GetEmployees()
        {
            var client = new HttpClient();
            var uri = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            var employeeList = new List<EmployeesResponse>();
            var response = client.GetAsync(uri)
                         .ContinueWith((taskresponse) =>
                         {
                             var resp = taskresponse.Result;
                             var jsonString = resp.Content.ReadAsStringAsync();
                             jsonString.Wait();
                             employeeList = JsonConvert.DeserializeObject<List<EmployeesResponse>>(jsonString.Result);
                         }); ;
            response.Wait();

            CalculateAnnualSalary(employeeList);
            return Task.FromResult<IEnumerable<EmployeesResponse>>(employeeList);
        }

        public static void CalculateAnnualSalary(List<EmployeesResponse> employeeList)
        {
            if (employeeList != null)
            {
                EmployeeAbstractFactory factory = new EmployeeFactory();
                Parallel.ForEach(employeeList, emp =>
                {
                    try
                    {
                        IEmployeeContract empContractType = factory.GetContractType(emp.ContractTypeName);
                        switch (emp.ContractTypeName)
                        {
                            case "HourlySalaryEmployee":
                                emp.AnnualSalary = empContractType.CalculateAnnualSalary(emp.HourlySalary);
                                break;

                            case "MonthlySalaryEmployee":
                                emp.AnnualSalary = empContractType.CalculateAnnualSalary(emp.MonthlySalary);
                                break;

                            default:
                                emp.AnnualSalary = 0;
                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                });
            }
        }
    }
}
