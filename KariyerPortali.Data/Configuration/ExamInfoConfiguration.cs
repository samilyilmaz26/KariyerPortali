using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
  public  class ExamInfoConfiguration:EntityTypeConfiguration<ExamInfo>
    {
         public ExamInfoConfiguration()
        {
            ToTable("ExamInfos");
            HasKey<int>(c => c.ExamInfoId);
            HasOptional<Exam>(c => c.Exam).WithMany(c => c.ExamInfos).HasForeignKey(c => c.ExamId).WillCascadeOnDelete(false);
            HasOptional<Resume>(c => c.Resume).WithMany(c => c.ExamInfos).HasForeignKey(c => c.ResumeId).WillCascadeOnDelete(false);
        }
    }
}
