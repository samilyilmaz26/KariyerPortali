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
    public interface ISkillInfoService
    {
        IEnumerable<SkillInfo> GetSkillInfos();
        Skill GetSkillInfo(int id);
        void CreateSkillInfo(SkillInfo skillInfo);
        void UpdateSkillInfo(SkillInfo skillInfo);
        void DeleteSkillInfo(SkillInfo skillInfo);
        void SaveSkillInfo();
    }
    public class SkillInfoService : ISkillInfoService
    {
        private readonly ISkillInfoRepository skillInfoRepository;
        private readonly IUnitOfWork unitOfWork;
        public SkillInfoService(ISkillInfoRepository skillInfoRepository, IUnitOfWork unitOfWork)
        {
            this.skillInfoRepository = skillInfoRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISkillInfoService Members
        public IEnumerable<SkillInfo> GetSkillInfos()
        {
            var skillInfos = skillInfoRepository.GetAll();
            return skillInfos;
        }
        public SkillInfo GetSkillInfo(int id)
        {
            var skillInfo = skillInfoRepository.GetById(id);
            return skillInfo;
        }
        public void CreateSkillInfo(SkillInfo skillInfo)
        {
            skillInfoRepository.Add(skillInfo);
        }
        public void UpdateSkillInfo(SkillInfo skillInfo)
        {
            skillInfoRepository.Update(skillInfo);
        }
        public void DeleteSkillInfo(SkillInfo skillInfo)
        {
            skillInfoRepository.Delete(skillInfo);
        }
        public void SaveSkillInfo()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
