using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
   public class JobApplication
    {
        public int ApplicationId { get; set; }

      
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

      
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

       
        public int JobId { get; set; }
        public Job Job { get; set; }

        public string CoverLetter { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        
    }
}
