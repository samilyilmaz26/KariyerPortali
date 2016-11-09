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
        IEnumerable<Employer> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
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
        public IEnumerable<Employer> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength,  out int  totalRecords, out int totalDisplayRecords)
        {
            var employers = employerRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            
            return employers;
        }
        public IEnumerable<Employer> GetEmployers()
        {
            var employers = employerRepository.GetAll("City");
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
