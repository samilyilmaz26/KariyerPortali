using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class CityConfiguration:EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            ToTable("Cities");
            HasKey<int>(c => c.CityId);
            Property(c => c.CityName).IsRequired().HasMaxLength(25);
            HasRequired<Country>(c => c.Country).WithMany(c => c.Cities).HasForeignKey(c=>c.CountryId);
            HasOptional<Country>(c => c.Country).WithMany().WillCascadeOnDelete(false);
        }

    }
}
