using CodeChallenge.Models;
using System;


namespace CodeChallenge.Services
{
    public interface IReportingStructureService
    {
        int GetNumberOfReports(Employee employee, int count);
        ReportingStructure GetReportingStructure(string id);
 
    }
}
