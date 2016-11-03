using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class JobConfiguration:EntityTypeConfiguration<Job>
    {
          public JobConfiguration()
        {
            /* Fluent-API */
            ToTable("Jobs");
            HasKey<int>(c=>c.JobId);
            
            //Property(c => c.JobType).HasMaxLength(500);
            Property(c => c.Responsibilities).IsRequired();
            Property(c => c.Qualifications).IsRequired();
            HasOptional<Employer>(c => c.Employer).WithMany().WillCascadeOnDelete(false);
           //foreign key olanları notnull yapayımmı
           
        }
    }
}
