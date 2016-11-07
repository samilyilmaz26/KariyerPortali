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
            HasKey<int>(c=>c.JobApplicationId);
            Property(c => c.CoverLetter).HasMaxLength(500);
            
            ////aşağıda jobapplication sınıfında bulunan foreignkey bağlama
            ////ve bire çok bağlamada null geçilebilir ilişkisi bulunuyor.
            //HasOptional<Employer>(s => s.Employer)
            //           .WithMany(s => s.JobApplications);
            //           //.HasForeignKey(s => s.EmployerId);
            //HasOptional<Employer>(s => s.Employer)
            //  .WithMany()
            //  .WillCascadeOnDelete(false);


            //HasOptional<Candidate>(s => s.Candidate)
            //           .WithMany(s => s.JobApplications);
            //           //.HasForeignKey(s => s.CandidateId);
            //HasOptional<Candidate>(s => s.Candidate)
            // .WithMany()
            // .WillCascadeOnDelete(false);


            //HasOptional<Job>(s => s.Job)
            //          .WithMany(s => s.JobApplications);
            //          //.HasForeignKey(s => s.JobId);
            //HasOptional<Job>(s => s.Job)
            // .WithMany()
            // .WillCascadeOnDelete(false);
        }
    }
}
