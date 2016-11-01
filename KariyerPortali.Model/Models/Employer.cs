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
        public int EmployerId { get; set; }
        public string Logo { get; set; }
        public string UserName { get; set; }
        public string EmployerName { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        public string Adress { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }


        public ICollection<JobApplication> JobApplications { get; set; }





    }
}
