using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular2.Leaning.Domain;

namespace Angular2.Leaning.Repository.Impl
{
    public class EmployeeRepository: BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public IEnumerable<Employee> Search(string term)
        {
            return
                DbContext.Set<Employee>()
                    .Where(x => x.FirstName.Contains(term.Trim()) || x.LastName.Contains(term.Trim()));
        }
    }
}
