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
    public interface IHighSchoolTypeService
    {
        IEnumerable<HighSchoolType> GetHighSchoolTypes();
        HighSchoolType GetHighSchoolType(int id);
        void CreateHighSchoolType(HighSchoolType highSchoolType);
        void UpdateHighSchoolType(HighSchoolType highSchoolType);
        void DeleteHighSchoolType(HighSchoolType highSchoolType);
        void SaveHighSchoolType();
    }
    public class HighSchoolTypeService : IHighSchoolTypeService
    {
        private readonly IHighSchoolTypeRepository highSchoolTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        public HighSchoolTypeService(IHighSchoolTypeRepository highSchoolTypeRepository, IUnitOfWork unitOfWork)
        {
            this.highSchoolTypeRepository = highSchoolTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IHighSchoolType Members
        public IEnumerable<HighSchoolType> GetHighSchoolTypes()
        {
            var highSchoolTypes = highSchoolTypeRepository.GetAll();
            return highSchoolTypes;
        }

        public HighSchoolType GetHighSchoolType(int id)
        {
            var highSchoolType = highSchoolTypeRepository.GetById(id);
            return highSchoolType;
        }

        public void CreateHighSchoolType(HighSchoolType highSchoolType)
        {
            highSchoolTypeRepository.Add(highSchoolType);
        }
        public void UpdateHighSchoolType(HighSchoolType highSchoolType)
        {
            highSchoolTypeRepository.Update(highSchoolType);
        }
        public void DeleteHighSchoolType(HighSchoolType highSchoolType)
        {
            highSchoolTypeRepository.Delete(highSchoolType);
        }
        public void SaveHighSchoolType()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}

