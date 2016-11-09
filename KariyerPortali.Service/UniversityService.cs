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
    public interface IUniversityService
    {
        IEnumerable<University> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<University> GetUniversities();
        University GetUniversity(int id);
        void CreateUniversity(University university);
        void UpdateUniversity(University university);
        void DeleteUniversity(University university);
        void SaveUniversity();
    }
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository universityRepository;
        private readonly IUnitOfWork unitOfWork;
        public UniversityService(IUniversityRepository universityRepository, IUnitOfWork unitOfWork)
        {
            this.universityRepository = universityRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IUniversityService Members
        public IEnumerable<University> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var universities = universityRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);
            return universities;
        }
        public IEnumerable<University> GetUniversities()
        {
            var universities = universityRepository.GetAll();
            return universities;
        }
        public University GetUniversity(int id)
        {
            var university = universityRepository.GetById(id);
            return university;
        }
        public void CreateUniversity(University university)
        {
            universityRepository.Add(university);
        }
        public void UpdateUniversity(University university)
        {
            universityRepository.Update(university);
        }
        public void DeleteUniversity(University university)
        {
            universityRepository.Delete(university);
        }
        public void SaveUniversity()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
