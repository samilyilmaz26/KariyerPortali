using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public string CvName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CitizenshipId { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
  
        [ForeignKey("City")]
        public int BirthCityId { get; set; }
        public City BirthCity { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Nationality { get; set; }

        public MilitaryService MilitaryService { get; set; }
        public DateTime MilitaryPostponeDate { get; set; }

        public bool DrivingLicenceExists { get; set; }

        public DrivingLicenceClass DrivingLicence1Class { get; set; }
        public DateTime DrivingLicence1Date { get; set; }

       
        public DrivingLicenceClass DrivingLicence2Class { get; set; }
        public DateTime DrivingLicence2Date { get; set; }

        public string CoverLetter { get; set; }

        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string CellPhone2 { get; set; }
        public string HomePhone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }

        ICollection<Experience> Experiences { get; set; }
        public ICollection<EducationInfo> EducationInfos { get; set; }

        public string HighSchoolName { get; set; }
        public int TypeId { get; set; }
        public HighSchoolType HighSchoolType { get; set; }

        public int HighSchoolDepartmentId { get; set; }
        public HighSchoolDepartment HighSchoolDepartment { get; set; }

        public DateTime HighSchoolStart { get; set; }
        public DateTime HighSchoolEnd { get; set; }
        public HighSchoolCertificate HighSchoolCertifacate { get; set; }
        public float CertifacateDegree { get; set; }






    }
}
