using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KariyerPortali.Model;
using KariyerPortali.Data.Configuration;

namespace KariyerPortali.Data
{
    public class KariyerPortaliEntities : DbContext
    {
        public KariyerPortaliEntities() : base("KariyerPortaliEntities") { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamInfo> ExamInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialRight> SocialRights { get; set; }
        public DbSet<University> Universities { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CandidateConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EmployerConfiguration());
            modelBuilder.Configurations.Add(new ExamConfiguration());
            modelBuilder.Configurations.Add(new ExperienceConfiguration());
            modelBuilder.Configurations.Add(new ExpertiseConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            modelBuilder.Configurations.Add(new JobApplicationConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new ResumeConfiguration());
            modelBuilder.Configurations.Add(new SectorConfiguration());
            modelBuilder.Configurations.Add(new SkillConfiguration());
            modelBuilder.Configurations.Add(new SocialRightConfiguration());
            modelBuilder.Configurations.Add(new UniversityConfiguration());
        }
    }
}
