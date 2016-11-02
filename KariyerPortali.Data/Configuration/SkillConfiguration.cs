using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class SkillConfiguration:EntityTypeConfiguration<Skill>
    {
      public SkillConfiguration()
        {
            /* Fluent-API */
            ToTable("Skills");
            HasKey<int>(c=>c.SkillId);
            Property(c => c.SkillName).IsRequired().HasMaxLength(200);
        }
    }
}
