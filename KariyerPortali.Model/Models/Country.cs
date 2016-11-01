using System.Collections.Generic;

namespace KariyerPortali.Model
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName{ get; set; }

        public ICollection<Employer> Employers { get; set; }
    }
}