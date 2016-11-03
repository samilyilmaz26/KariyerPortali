using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
   
    public class HighSchoolTypeRepository : RepositoryBase<HighSchoolType>, IHighSchoolDepartmentRepository
    {
        public HighSchoolTypeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
    public interface IHighSchoolTypeRepository : IRepository<HighSchoolType>
        {
            ToTable("EducationInfos");
            HasKey<int>(c => c.EducationInfoId);
            HasOptional<Department>(c => c.Department).WithMany(c => c.EducationInfos).HasForeignKey(c => c.DepartmentId).WillCascadeOnDelete(false);
        }
    }
}
