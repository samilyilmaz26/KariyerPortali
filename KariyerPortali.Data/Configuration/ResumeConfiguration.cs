using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace KariyerPortali.Data.Configuration
{
    public class ResumeConfiguration: EntityTypeConfiguration<Resume>
    {
        public ResumeConfiguration()
        {
            /* Fluent-API */
            ToTable("Resumes");
            Property(c => c.CvName).IsRequired().HasMaxLength(200);
        }
    }
}
