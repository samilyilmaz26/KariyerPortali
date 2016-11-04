using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class EmployerConfiguration:EntityTypeConfiguration<Employer>
    {
        public EmployerConfiguration()
        {
            ToTable("Employers");
            HasKey<int>(c => c.EmployerId);
            Property(c => c.Logo).HasMaxLength(250);
            Property(c => c.UserName).IsRequired().HasMaxLength(250);
            Property(c => c.EmployerName).IsRequired().HasMaxLength(250);
            Property(c => c.Address).IsRequired().HasMaxLength(250);
            Property(c => c.Phone).IsRequired().HasMaxLength(15);
            Property(c => c.Email).IsRequired().HasMaxLength(50);
            Property(c => c.WebSite).IsRequired().HasMaxLength(50);
            Property(c => c.CreateDate).IsRequired();
            Property(c => c.UpdatedBy).IsRequired().HasMaxLength(100);
            Property(c => c.UpdateDate).IsRequired();
            HasOptional<Sector>(c => c.Sector)
                .WithMany(c => c.Employers)
                .HasForeignKey(c => c.SectorId);
            HasOptional<Sector>(c => c.Sector)
                .WithMany()
                .WillCascadeOnDelete(false);
            HasOptional<City>(c => c.City)
                .WithMany(c => c.Employers)
                .HasForeignKey(c => c.CityId);
            HasOptional<City>(c => c.City)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
