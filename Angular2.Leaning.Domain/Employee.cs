using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular2.Leaning.Domain
{
    public class Employee:AggregateRoot
    {
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }    
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; private set; }
        public DateTime BirthDate { get; private set; }

        public static Employee Create(string firstName, string lastName, int age, DateTime birthDate)
        {
            return new Employee
            {
                Id=Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                BirthDate = birthDate
            };
        }

        public void Update(string firstName, string lastName, int age, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BirthDate = birthDate;
        }

       
       
    }
}
