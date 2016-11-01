using System.Collections.Generic;

namespace KariyerPortali.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public ICollection<Employer> Employers { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}