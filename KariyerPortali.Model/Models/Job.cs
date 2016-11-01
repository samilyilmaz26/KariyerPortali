using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KariyerPortali.Model
{
   

    public class SocialRight
    {
        string Food;
        string Service;
        string Insurance;
    }

    public class Job
    {
        public int JobId { get; set; }

        [ForeignKey("Employer")]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        public string JobType { get; set; }

        public string Experience { get; set; }
        public Experience Experience { get; set; }

        public ICollection<SocialRight> SocialRights { get; set; }

        public string Description { get; set; }

        public string Responsibilities { get; set; }

        public string Qualifications { get; set; }

        public DateTime Createdate { get; set; }

        [StringLenght(200)]
        public string CreatedBy { get; set; }

        public DateTime UpdateDate { get; set; }

        [StringLenght(200)]
        public string UpdateBy { get; set; }
    }
}