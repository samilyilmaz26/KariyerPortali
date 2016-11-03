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
    public interface IHighSchoolDepartmentService
    {
        IEnumerable<HighSchoolDepartment> GetHighSchoolDepartments();
        HighSchoolDepartment GetHighSchoolDepartment(int id);
        void CreateHighSchoolDepartment(HighSchoolDepartment highSchoolDepartment);
        void UpdateHighSchoolDepartment(HighSchoolDepartment highSchoolDepartment);
        void DeleteHighSchoolDepartment(HighSchoolDepartment highSchoolDepartment);
        void SaveHighSchoolDepartment();
    }
    public class HighSchoolDepartmentService : IHighSchoolDepartmentService
    {
        private readonly IHighSchoolDepartmentRepository highSchoolDepartmentRepository;
        private readonly IUnitOfWork unitOfWork;
        public HighSchoolDepartmentService(IHighSchoolDepartmentRepository highSchoolDepartmentRepository, IUnitOfWork unitOfWork)
        {
            this.highSchoolDepartmentRepository = highSchoolDepartmentRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IHighSchoolDepartment Members
        public IEnumerable<HighSchoolDepartment> GetHighSchoolDepartments()
        {
            var highSchoolDepartments = highSchoolDepartmentRepository.GetAll();
            return highSchoolDepartments;
        }

        public HighSchoolDepartment GetHighSchoolDepartment(int id)
        {
            var highSchoolDepartment = highSchoolDepartmentRepository.GetById(id);
            return highSchoolDepartment;
        }

        public void CreateHighSchoolDepartment(HighSchoolDepartment highSchoolDepartment)
        {
            highSchoolDepartmentRepository.Add(highSchoolDepartment);
        }
        public void UpdateHighSchoolDepartment(HighSchoolDepartment highSchoolDepartment)
        {
            highSchoolDepartmentRepository.Update(highSchoolDepartment);
        }
        public void DeleteHighSchoolDepartment(HighSchoolDepartment highSchoolDepartment)
        {
            highSchoolDepartmentRepository.Delete(highSchoolDepartment);
        }
        public void SaveHighSchoolDepartment()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
