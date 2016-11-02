using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class CourseConfiguration:EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Courses");
            HasKey<int>(c => c.CourseId);
            Property(c => c.CourseName).IsRequired();
            Property(c => c.Institution).IsRequired();
            Property(c => c.StartDate).IsRequired();
            Property(c => c.FinishDate).IsRequired();
            Property(c => c.Time).IsRequired();
            Property(c => c.Statement).IsRequired();
        }
    }
}
