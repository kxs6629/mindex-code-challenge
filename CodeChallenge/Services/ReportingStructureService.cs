using Microsoft.Extensions.Logging;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;
using System;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly ILogger<ReportingStructureService> _logger;
        private EmployeeService _employeeService;
        public ReportingStructureService(ILogger<ReportingStructureService> logger,EmployeeService employeeService) 
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public int GetNumberOfReports(Employee employee, int count)
        {
            foreach (Employee entry in employee.DirectReports)
            {
                if (entry.DirectReports.Count > 0)
                    GetNumberOfReports(entry, count++);
            }
            return count;
        }

        public ReportingStructure GetReportingStructure(string id)
        {
            Employee e = _employeeService.GetById(id);
            if (e == null) 
                return null;
            int numberOfReports = GetNumberOfReports(e, 0);
            ReportingStructure rs = new ReportingStructure();
            rs.employee = e;
            rs.numberOfReports = numberOfReports;
            return rs;
        }
    }
}
