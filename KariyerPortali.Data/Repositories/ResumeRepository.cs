using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{

    public class ResumeRepository : RepositoryBase<Resume>, IResumeRepository
    {
        public ResumeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IResumeRepository : IRepository<Resume>
    {

    }
}
