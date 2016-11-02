using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    
    public class SocialRightRepository : RepositoryBase<SocialRight>, ISocialRightRepository
    {
        public SocialRightRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface ISocialRightRepository : IRepository<SocialRight>
    {

    }
}
