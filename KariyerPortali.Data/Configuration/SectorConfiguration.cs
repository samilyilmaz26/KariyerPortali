using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
  public  class SectorConfiguration:EntityTypeConfiguration<Sector>
    {
            public SectorConfiguration()
        {
            /* Fluent-API */
            ToTable("Sectors");
            HasKey<int>(c=>c.SectorId);
            Property(c => c.SectorName).IsRequired().HasMaxLength(200);
        }
    }
}
