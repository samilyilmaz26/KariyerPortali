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




    }
}
