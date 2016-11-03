using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class University
    {

        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public ICollection<EducationInfo> EducationInfos { get; set; }
    }
}