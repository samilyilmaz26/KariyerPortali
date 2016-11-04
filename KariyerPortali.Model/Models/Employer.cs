using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
   public class Employer
   {
       public Employer()
       {
           Jobs = new List<Job>();
       }

        public int EmployerId { get; set; }
        public string Logo { get; set; }
        public string UserName { get; set; }
        public string EmployerName { get; set; }

    
        public int? SectorId { get; set; }
        public Sector Sector { get; set; }

        public string Address { get; set; }

     
        public int? CityId { get; set; }
        public City City { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }


        public ICollection<JobApplication> JobApplications { get; set; }

        public ICollection<Job> Jobs { get; set; }





    }
}
