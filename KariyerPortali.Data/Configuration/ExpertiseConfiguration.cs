using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class ExpertiseConfiguration:EntityTypeConfiguration<Expertise>
    {
        public ExpertiseConfiguration()
        {
            ToTable("Expertises");
            HasKey<int>(c => c.ExpertiseId);
            Property(c => c.ExpertiseName).IsRequired();
        }
    }
}
