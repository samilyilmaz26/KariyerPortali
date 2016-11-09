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
    public interface IDepartmentService
    {
        IEnumerable<Department> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        void SaveDepartment();
    }
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IUnitOfWork unitOfWork;
        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
        }
       
        #region IDepartmentService Members
        public IEnumerable<Department> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var departments = departmentRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return departments;
        }
        public IEnumerable<Department> GetDepartments()
        {
            var departments = departmentRepository.GetAll("DepartmentName");
            return departments;
        }
        public Department GetDepartment(int id)
        {
            var department = departmentRepository.GetById(id);
            return department;
        }
        public void CreateDepartment(Department department)
        {
            departmentRepository.Add(department);
        }
        public void UpdateDepartment(Department department)
        {
            departmentRepository.Update(department);
        }
        public void DeleteDepartment(Department department)
        {
            departmentRepository.Delete(department);
        }
        public void SaveDepartment()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
