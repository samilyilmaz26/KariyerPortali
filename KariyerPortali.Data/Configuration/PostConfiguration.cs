using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
   public class PostConfiguration:EntityTypeConfiguration<Post>
    {
       public PostConfiguration()
        {
            /* Fluent-API */
            ToTable("Posts");
            HasKey<int>(c=>c.PostId);
            Property(c => c.Title).IsRequired().HasMaxLength(100);
            Property(c => c.Body).IsRequired();
        }
    }
}
