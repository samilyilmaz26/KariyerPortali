using KariyerPortali.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IGenderRepository : IRepository<Gender>
    {

    }
}
