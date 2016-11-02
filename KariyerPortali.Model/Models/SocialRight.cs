using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class SocialRight
    {
        public int SocialRightId { get; set; }
        public string SocialRightName { get; set; }

        public ICollection<Job>Jobs { get; set; }
    }
}
