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
    public interface IExamInfoService
    {
        IEnumerable<ExamInfo> GetExamInfos();
        ExamInfo GetExamInfo(int id);
        void CreateExamInfo(ExamInfo examInfo);
        void UpdateExamInfo(ExamInfo examInfo);
        void DeleteExamInfo(ExamInfo examInfo);
        void SaveExamInfo();
    }
    public class ExamInfoService : IExamInfoService
    {
        private readonly IExamInfoRepository examInfoRepository;
        private readonly IUnitOfWork unitOfWork;
        public ExamInfoService(IExamInfoRepository examInfoRepository, IUnitOfWork unitOfWork)
        {
            this.examInfoRepository = examInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IExamInfoService Members
        public IEnumerable<ExamInfo> GetExamInfos()
        {
            var examInfos = examInfoRepository.GetAll();
            return examInfos;
        }
        public ExamInfo GetExamInfo(int id)
        {
            var examInfo = examInfoRepository.GetById(id);
            return examInfo;
        }
        public void CreateExamInfo(ExamInfo examInfo)
        {
            examInfoRepository.Add(examInfo);
        }
        public void UpdateExamInfo(ExamInfo examInfo)
        {
            examInfoRepository.Update(examInfo);
        }
        public void DeleteExamInfo(ExamInfo examInfo)
        {
            examInfoRepository.Delete(examInfo);
        }
        public void SaveExamInfo()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
