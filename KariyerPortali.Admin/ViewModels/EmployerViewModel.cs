using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class EmployerViewModel
    {
        

        public int EmployerId { get; set; }
        public string Logo { get; set; }
        public string UserName { get; set; }
        public string EmployerName { get; set; }
        
        public string SectorName { get; set;  }

        public string Address { get; set; }

        public string CityName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }


     


    }
}