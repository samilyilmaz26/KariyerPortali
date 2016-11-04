using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class SocialRightConfiguration:EntityTypeConfiguration<SocialRight>
    {
        public SocialRightConfiguration()
        {
            /* Fluent-API */
            ToTable("SocialRights");
            HasKey<int>(c=>c.SocialRightId);
            Property(c => c.SocialRightName).IsRequired().HasMaxLength(200);
            HasOptional<Job>(s => s.Job)
                                 .WithMany(s => s.SocialRights)
                                 .HasForeignKey(s => s.JobId);
            HasOptional<Job>(s => s.Job)
             .WithMany()
             .WillCascadeOnDelete(false);           
           
        }
    }
}
