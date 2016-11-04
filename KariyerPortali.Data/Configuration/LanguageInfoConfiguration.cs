using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class LanguageInfoConfiguration : EntityTypeConfiguration<LanguageInfo>
    {
        public LanguageInfoConfiguration()
        {
            ToTable("LanguageInfos");
            HasKey<int>(c => c.LanguageInfoId);
            
           
            HasOptional<Language>(c => c.Language)
                .WithMany(c => c.LanguageInfos)
                .HasForeignKey(c => c.LanguageId);
            HasOptional<Language>(c => c.Language)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
