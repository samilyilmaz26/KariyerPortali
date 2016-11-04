using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class SkillInfoConfiguration:EntityTypeConfiguration<SkillInfo>
    {
        public SkillInfoConfiguration()
        {
            ToTable("SkillInfos");
            HasKey<int>(c => c.SkillInfoId);

            HasOptional<Skill>(s => s.Skill)
                     .WithMany(s => s.SkillInfos)
                     .HasForeignKey(s => s.SkillId);
            HasOptional<Skill>(s => s.Skill)
             .WithMany()
             .WillCascadeOnDelete(false);

            HasOptional<Resume>(s => s.Resume)
                     .WithMany(s => s.SkillInfos)
                     .HasForeignKey(s => s.ResumeId);
            HasOptional<Resume>(s => s.Resume)
             .WithMany()
             .WillCascadeOnDelete(false);

        }
    }
}
