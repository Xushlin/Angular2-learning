using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Angular2.Leaning.API.DTOAdapter;
using Angular2.Leaning.Command;
using Angular2.Leaning.DomainService;
using Angular2.Leaning.DTO;

namespace Angular2.Leaning.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Route("")]
        public IEnumerable<Employee> GetAll()
        {
            return _employeeService.GetAll().Select(x=>x.ToDto());
        }

        [Route("search/{term}")]
        public IEnumerable<Employee> Search(string term)
        {
            return _employeeService.Search(term).Select(x=>x.ToDto());
        }

        [Route("{id}")]
        public Employee GetById(Guid id)
        {
            return _employeeService.Get(id).ToDto();
        }


        [HttpPost]
        [Route("add")]
        public void CreateUser(EmployeeCommand command)
        {
            _employeeService.Add(command);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateUser(EmployeeCommand command)
        {
            _employeeService.Update(command);
        }

       
        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _employeeService.Delete(id);
        }
    }
}