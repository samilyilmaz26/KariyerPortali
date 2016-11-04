using System.Collections.Generic;

namespace KariyerPortali.Model
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName{ get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }
}