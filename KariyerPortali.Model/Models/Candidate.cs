using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public DateTime CreateDate{ get; set; }
        public bool State { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }
        public ICollection<Resume> Resumes { get; set; }


    }
}
