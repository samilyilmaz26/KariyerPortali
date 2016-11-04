using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface IJobApplicationService
    {
        IEnumerable<JobApplication> GetJobApplications();
        JobApplication GetJobApplication(int id);
        IEnumerable<JobApplication> Search(string search);
        void CreateJobApplication(JobApplication jobApplication);
        void UpdateJobApplication(JobApplication jobApplication);
        void DeleteJobApplication(JobApplication jobApplication);
        void SaveJobApplication();
    }
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository jobApplicationRepository;
        private readonly IUnitOfWork unitOfWork;
        public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IUnitOfWork unitOfWork)
        {
            this.jobApplicationRepository = jobApplicationRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IJobApplicationService Members

        public IEnumerable<JobApplication> Search(string search)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = GetJobApplications();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    DateTime dDate;
                    bool dateParsed = false;
                    if (DateTime.TryParse(sSearch, out dDate))
                    {
                        dDate = DateTime.Parse(sSearch);
                        dateParsed = true;
                    }
                    query = query.Where(j => j.Candidate.FirstName.Contains(sSearch) ||
                   j.Candidate.LastName.Contains(sSearch) || j.Employer.EmployerName.Contains(sSearch) ||
                   j.Job.Title.Contains(sSearch) || (dateParsed == true ? j.ApplicationDate == dDate : false) ||
                   (dateParsed == true ? j.UpdateDate == dDate : false)
                    );
                }
            }
            return query;

        }

        private object GetJobApplication()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobApplication> GetJobApplications()
        {
            var jobApplications = jobApplicationRepository.GetAll();
            return jobApplications;
        }
        public JobApplication GetJobApplication(int id)
        {
            var jobApplication = jobApplicationRepository.GetById(id);
            return jobApplication;
        }
        public void CreateJobApplication(JobApplication jobApplication)
        {
            jobApplicationRepository.Add(jobApplication);
        }
        public void UpdateJobApplication(JobApplication jobApplication)
        {
            jobApplicationRepository.Update(jobApplication);
        }
        public void DeleteJobApplication(JobApplication jobApplication)
        {
            jobApplicationRepository.Delete(jobApplication);
        }
        public void SaveJobApplication()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
