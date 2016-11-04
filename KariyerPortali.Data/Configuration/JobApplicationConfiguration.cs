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
           //aşağıda jobapplication sınıfında bulunan foreignkey bağlama
           //ve bire çok bağlamada null geçilebilir ilişkisi bulunuyor.
            HasOptional<Employer>(c => c.Employer).WithMany(c => c.JobApplications).HasForeignKey(c => c.EmployerId).WillCascadeOnDelete(false);
            HasOptional<Candidate>(c => c.Candidate).WithMany(c => c.JobApplications).HasForeignKey(c => c.CandidateId).WillCascadeOnDelete(false);
            HasOptional<Job>(c => c.Job).WithMany(c => c.JobApplications).HasForeignKey(c => c.JobId).WillCascadeOnDelete(false);
        }
    }
}
