using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
   
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IDepartmentRepository : IRepository<Department>
    {

    }
}
