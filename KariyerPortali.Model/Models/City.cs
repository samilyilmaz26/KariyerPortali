using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KariyerPortali.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

       
        public int? CountryId { get; set; }
        public virtual Country Country { get;set;}
        public virtual ICollection<Employer> Employers { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }

    }
}