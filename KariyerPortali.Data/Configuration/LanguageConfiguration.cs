using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class LanguageConfiguration:EntityTypeConfiguration<Language>
    {
         public LanguageConfiguration()
        {
            /* Fluent-API */
            ToTable("Languages");
            HasKey<int>(c=>c.LanguageId);
            Property(c => c.LanguageName).IsRequired().HasMaxLength(100);
        }
    }
}
