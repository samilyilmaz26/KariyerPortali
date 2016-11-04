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
    public interface IEmployerService
    {
        IEnumerable<Employer> GetEmployers();
        Employer GetEmployer(int id);
        void CreateEmployer(Employer employer);
        void UpdateEmployer(Employer employer);
        void DeleteEmployer(Employer employer);
        void SaveEmployer();
    }
    public class EmployerService:IEmployerService
    {
        private readonly IEmployerRepository employerRepository;
        private readonly IUnitOfWork unitOfWork;
        public EmployerService(IEmployerRepository employerRepository, IUnitOfWork unitOfWork)
        {
            this.employerRepository = employerRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IEmployerService Members
        public IEnumerable<Employer> Search(string search)
        {
            search = search.ToLower().Trim();
            var searchWords = search.Split(' ');


            var query = GetEmployers();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.EmployerName.Contains(sSearch)|| c.City.CityName.Contains(sSearch) || c.Email.Contains(sSearch));
                }
            }

            return query;

        }
        public IEnumerable<Employer> GetEmployers()
        {
            var employers = employerRepository.GetAll();
            return employers;
        }
        public Employer GetEmployer(int id)
        {
            var employer = employerRepository.GetById(id);
            return employer;
        }
        public void CreateEmployer(Employer employer)
        {
            employerRepository.Add(employer);
        }
        public void UpdateEmployer(Employer employer)
        {
            employerRepository.Update(employer);
        }
        public void DeleteEmployer(Employer employer)
        {
            employerRepository.Delete(employer);
        }
        public void SaveEmployer()
        {
            unitOfWork.Commit();
        }
    
        #endregion
    }
}
