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
        public string ResumeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CitizenshipId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int ViewCount { get; set; }


        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [ForeignKey("BirthCity")]
        public int BirthCityId { get; set; }
        public City BirthCity { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        [ForeignKey("Nationality")]
        public int CountryId { get; set; }
        public Country Nationality { get; set; }

        public MilitaryService MilitaryService { get; set; }
        public DateTime MilitaryPostponeDate { get; set; }

        public bool DrivingLicenseExists { get; set; }

        public DrivingLicenseClass DrivingLicense1Class { get; set; }
        public DateTime DrivingLicense1Date { get; set; }


        public DrivingLicenseClass DrivingLicense2Class { get; set; }
        public DateTime DrivingLicense2Date { get; set; }

        public string CoverLetter { get; set; }

        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string CellPhone2 { get; set; }
        public string HomePhone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }

        public ICollection<Experience> Experiences { get; set; }
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

        public ICollection<LanguageInfo> LanguageInfos { get; set; }

        public string ComputerSkill { get; set; }
        public string Certificate { get; set; }

        public ICollection<ExamInfo> ExamInfos { get; set; }
        public ICollection<SkillInfo> SkillInfos { get; set; }
        public ICollection<Course> Courses { get; set; }
        public string ScholarshipAndProject { get; set; }
        public string Hobby { get; set; }
        public string MemberOwnedCommunity { get; set; }

        public BloodType BloodType { get; set; }
        public CigaretteStatus CigaretteStatus { get; set; }
        public SalaryWaited SalaryWaited { get; set; }
        public ICollection<Reference> References { get; set; }






    }
}
