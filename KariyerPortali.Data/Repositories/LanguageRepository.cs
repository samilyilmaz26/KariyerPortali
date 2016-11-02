using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
    {
        public LanguageRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface ILanguageRepository : IRepository<Language>
    {

    }
}
