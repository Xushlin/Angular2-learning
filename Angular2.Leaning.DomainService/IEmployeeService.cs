using System;
using System.Collections.Generic;
using Angular2.Leaning.Command;
using Angular2.Leaning.Domain;

namespace Angular2.Leaning.DomainService
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        void Add(EmployeeCommand employeeCommand);
        void Update(EmployeeCommand employeeCommand);
        void Delete(Guid id);
        Employee Get(Guid id);
        IEnumerable<Employee> Search(string term);
    }
}