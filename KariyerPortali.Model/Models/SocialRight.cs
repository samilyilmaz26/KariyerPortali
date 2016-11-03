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

        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
