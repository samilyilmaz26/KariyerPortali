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
    public interface IJobService
    {
        IEnumerable<Job> Search(string search);
        IEnumerable<Job> GetJobs();
        Job GetJob(int id);
        void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(Job job);
        void SaveJob();
    }
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IUnitOfWork unitOfWork;
        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            this.jobRepository = jobRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IJobService Members
        public IEnumerable<Job> Search(string search)
        {
            search = search.ToLower().Trim();
            var searchWords = search.Split(' ');


            var query = GetJobs();
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
                    query = query.Where(c=>c.Title.Contains(sSearch) || c.Description.Contains(sSearch) || c.Employer.EmployerName.Contains(sSearch)  || c.Employer.City.CityName.Contains(sSearch)|| c.JobType.ToString().Contains(sSearch) || (dateParsed == true ? c.Createdate == dDate : false));
                }
            }
            return query;

        }
        public IEnumerable<Job> GetJobs()
        {
            var jobs = jobRepository.GetAll();
            return jobs;
        }
        public Job GetJob(int id)
        {
            var job = jobRepository.GetById(id);
            return job;
        }
        public void CreateJob(Job job)
        {
            jobRepository.Add(job);
        }
        public void UpdateJob(Job job)
        {
            jobRepository.Update(job);
        }
        public void DeleteJob(Job job)
        {
            jobRepository.Delete(job);
        }
        public void SaveJob()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
