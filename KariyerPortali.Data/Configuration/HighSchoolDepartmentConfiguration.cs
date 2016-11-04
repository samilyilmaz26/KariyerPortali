using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class HighSchoolDepartmentConfiguration:EntityTypeConfiguration<HighSchoolDepartment>
    {
        public HighSchoolDepartmentConfiguration()
        {
            ToTable("HighSchoolDepartments");
            HasKey<int>(c => c.HighSchoolDepartmentId);
            Property(c => c.DepartmentName).IsRequired();
        }
    }
}
