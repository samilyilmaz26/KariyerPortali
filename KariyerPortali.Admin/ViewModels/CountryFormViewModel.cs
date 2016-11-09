using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class CountryFormViewModel
    {
        public int CountryId { get; set; }
        
       
        [DisplayName("Ülke Adı")]
        public string CountryName { get; set; }
     //   public ICollection<City> Cities { get; set; }
    }
}