using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class ReferenceConfiguration:EntityTypeConfiguration<Reference>
    {
        public ReferenceConfiguration()
        {
            ToTable("References");
            HasKey<int>(c => c.ReferenceId);
            Property(c => c.FirstName).IsRequired();
            Property(c => c.LastName).IsRequired();
            Property(c => c.Phone).IsRequired();
            HasOptional<Sector>(c => c.Sector).WithMany(c => c.References).HasForeignKey(c => c.SectorId).WillCascadeOnDelete(false);

        }
    }
}
