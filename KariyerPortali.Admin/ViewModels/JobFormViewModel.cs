using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class JobFormViewModel
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        public JobType JobType { get; set; }

        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }

        public string Responsibilities { get; set; }
        public string Qualifications { get; set; }
        public DateTime Createdate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}