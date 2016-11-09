using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class CandidateConfiguration:EntityTypeConfiguration<Candidate>
    {
        public CandidateConfiguration()
        {
            ToTable("Candidates");
            HasKey<int>(c => c.CandidateId);
            Property(c => c.UserName).HasMaxLength(50).IsRequired();
            Property(c => c.FirstName).HasMaxLength(50);
            Property(c => c.LastName).HasMaxLength(50);
            Property(c => c.Email).HasMaxLength(100);
            Property(c => c.Phone).HasMaxLength(24);
        }

        }
    }
