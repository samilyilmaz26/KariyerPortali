using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        
        public ICollection<Employer>Employers { get; set; }
    }
}