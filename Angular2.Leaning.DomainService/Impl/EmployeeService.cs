using System;
using System.Collections.Generic;
using Angular2.Leaning.Command;
using Angular2.Leaning.Domain;
using Angular2.Leaning.Repository;
using Angular2.Leaning.Repository.UnitOfWork;

namespace Angular2.Leaning.DomainService.Impl
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public EmployeeService(IEmployeeRepository employeeRepository,IUnitOfWorkFactory unitOfWorkFactory)
        {
            _employeeRepository = employeeRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public void Add(EmployeeCommand employeeCommand)
        {
            var user = Employee.Create(employeeCommand.FirstName, employeeCommand.LastName, employeeCommand.Age,
                employeeCommand.BirthDate);

            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Add(user);
                unitOfWork.Commit();
            }
        }

        public void Update(EmployeeCommand employeeCommand)
        {
            var employee = _employeeRepository.Get(employeeCommand.Id);
            employee.Update(employeeCommand.FirstName, employeeCommand.LastName, employeeCommand.Age,employeeCommand.BirthDate);
            using (var unitOfWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Edit(employee);
                unitOfWork.Commit();
            }
        }

        public void Delete(Guid id)
        {
            _employeeRepository.Delete(id);
        }

        public Employee Get(Guid id)
        {
            return _employeeRepository.Get(id);
        }

        public IEnumerable<Employee> Search(string term)
        {
            return _employeeRepository.Search(term);
        }
    }
}
