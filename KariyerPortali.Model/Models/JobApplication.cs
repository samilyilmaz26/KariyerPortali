using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
   public class JobApplication
    {
        public int ApplicationId { get; set; }
        public Candidate FirstName { get; set; }
        public Candidate LastName { get; set; }
        public Employer CompanyName { get; set; }
        public Job JobDescription { get; set; }
        public string CoverLetter { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
