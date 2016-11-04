using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class UniversityViewModel
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public ICollection<EducationInfo> EducationInfos { get; set; }
    }
}