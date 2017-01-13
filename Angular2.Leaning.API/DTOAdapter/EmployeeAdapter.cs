using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Angular2.Leaning.DTO;

namespace Angular2.Leaning.API.DTOAdapter
{
    public static class EmployeeAdapter
    {
        public static Employee ToDto(this Domain.Employee me)
        {
            return new Employee
            {
                Id = me.Id,
                LastName = me.LastName,
                FirstName = me.FirstName,
                Age = me.Age,
                BirthDate = me.BirthDate,
            };
        }
    }
}