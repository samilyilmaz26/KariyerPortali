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
    public interface IEducationInfoService
    {
        IEnumerable<EducationInfo> GetEducationInfos();
        EducationInfo GetEducationInfo(int id);
        void CreateEducationInfo(EducationInfo educationInfo);
        void UpdateEducationInfo(EducationInfo educationInfo);
        void DeleteEducationInfo(EducationInfo educationInfo);
        void SaveEducationInfo();
    }
    public class EducationInfoService : IEducationInfoService
    {
        private readonly IEducationInfoRepository educationInfoRepository;
        private readonly IUnitOfWork unitOfWork;
        public EducationInfoService(IEducationInfoRepository educationInfoRepository, IUnitOfWork unitOfWork)
        {
            this.educationInfoRepository = educationInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IEducationInfoService Members
        public IEnumerable<EducationInfo> GetEducationInfos()
        {
            var educationInfos = educationInfoRepository.GetAll();
            return educationInfos;
        }
        public EducationInfo GetEducationInfo(int id)
        {
            var educationInfo = educationInfoRepository.GetById(id);
            return educationInfo;
        }
        public void CreateEducationInfo(EducationInfo educationInfo)
        {
            educationInfoRepository.Add(educationInfo);
        }
        public void UpdateEducationInfo(EducationInfo educationInfo)
        {
            educationInfoRepository.Update(educationInfo);
        }
        public void DeleteEducationInfo(EducationInfo educationInfo)
        {
            educationInfoRepository.Delete(educationInfo);
        }
        public void SaveEducationInfo()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
