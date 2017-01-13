using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular2.Leaning.Domain;

namespace Angular2.Leaning.Data.Mappings
{
    public class EmployeeMap: EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(x => x.Id).Property(x => x.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(128);
            Property(x => x.LastName).IsRequired().HasMaxLength(128);
            Property(x => x.Age).IsRequired();
            Property(x => x.BirthDate);
        }
    }
}
