using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class JobApplicationConfiguration:EntityTypeConfiguration<JobApplication>
    {
       public JobApplicationConfiguration()
        {
            /* Fluent-API */
            ToTable("JobApplications");
            HasKey<int>(c=>c.ApplicationId);
            Property(c => c.CoverLetter).HasMaxLength(500);
           
        }
    }
}
