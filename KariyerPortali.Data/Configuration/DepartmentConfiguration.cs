using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class DepartmentConfiguration:EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("Departments");
            HasKey<int>(c => c.DepartmentId);
            Property(c => c.DepartmentName).IsRequired().HasMaxLength(100);
        }
    }
}
