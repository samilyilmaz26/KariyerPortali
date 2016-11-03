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
    public interface ILanguageInfoService
    {
        IEnumerable<LanguageInfo> GetLanguageInfos();
        LanguageInfo GetLanguageInfo(int id);
        void CreateLanguageInfo(LanguageInfo languageInfo);
        void UpdateLanguageInfo(LanguageInfo languageInfo);
        void DeleteLanguageInfo(LanguageInfo languageInfo);
        void SaveLanguageInfo();
    }
    public class LanguageInfoService : ILanguageInfoService
    {
        private readonly ILanguageInfoRepository languageInfoRepository;
        private readonly IUnitOfWork unitOfWork;
        public LanguageInfoService(ILanguageInfoRepository languageInfoRepository, IUnitOfWork unitOfWork)
        {
            this.languageInfoRepository = languageInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ILanguageInfoService Members
        public IEnumerable<LanguageInfo> GetLanguageInfos()
        {
            var languageInfos = languageInfoRepository.GetAll();
            return languageInfos;
        }
        public LanguageInfo GetLanguageInfo(int id)
        {
            var languageInfo=languageInfoRepository.GetById(id);
            return languageInfo;
        }
        public void CreateLanguageInfo(LanguageInfo languageInfo)
        {
            languageInfoRepository.Add(languageInfo);
        }
        public void UpdateLanguageInfo(LanguageInfo languageInfo)
        {
            languageInfoRepository.Update(languageInfo);
        }
        public void DeleteLanguageInfo(LanguageInfo languageInfo)
        {
            languageInfoRepository.Delete(languageInfo);
        }
        public void SaveLanguageInfo()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
