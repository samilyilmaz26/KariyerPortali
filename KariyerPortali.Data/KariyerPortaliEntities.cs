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
        public DbSet<Country> Candidate { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Exam> Exams { get; set; }
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
            modelBuilder.Configurations.Add(new ResumeConfiguration());
        }
    }
}
