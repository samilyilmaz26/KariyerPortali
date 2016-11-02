using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class EmployerConfiguration:EntityTypeConfiguration<Employer>
    {
        public EmployerConfiguration()
        {
            ToTable("Employers");
            HasKey<int>(c => c.EmployerId);
            Property(c => c.Logo).HasMaxLength(250);
            Property(c => c.UserName).HasMaxLength(250);
        }
    }
}
