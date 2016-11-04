namespace KariyerPortali.Model
{
    public class EducationInfo
    {
        public int EducationInfoId { get; set; }
        public EducationStatus EducationStatus { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int ResumeId { get; set; }
        public Resume Resume { get; set; }


    }
}