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
                    query = query.Where(c => c.JobId.ToString().Contains(sSearch) || c.Description.Contains(sSearch) || c.Employer.EmployerName.Contains(sSearch));
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
