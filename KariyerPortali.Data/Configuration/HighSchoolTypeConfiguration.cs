using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class HighSchoolTypeConfiguration:EntityTypeConfiguration<HighSchoolType>
    {
        public HighSchoolTypeConfiguration()
        {
            ToTable("HighSchoolTypes");
            HasKey<int>(c => c.HighSchoolTypeId);
            Property(c => c.TypeName).IsRequired();
        }
    }
}
