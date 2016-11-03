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
    public interface ISocialRightService
    {
        IEnumerable<SocialRight> GetSocialRights();
        SocialRight GetSocialRight(int id);
        void CreateSocialRight(SocialRight socialRight);
        void UpdateSocialRight(SocialRight socialRight);
        void DeleteSocialRight(SocialRight socialRight);
        void SaveSocialRight();
    }
    public class SocialRightService : ISocialRightService
    {
        private readonly ISocialRightRepository socialRightRepository;
        private readonly IUnitOfWork unitOfWork;
        public SocialRightService(ISocialRightRepository socialRightRepository, IUnitOfWork unitOfWork)
        {
            this.socialRightRepository = socialRightRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ISocialRightService Members
        public IEnumerable<SocialRight> GetSocialRights()
        {
            var socialRights = socialRightRepository.GetAll();
            return socialRights;
        }
        public SocialRight GetSocialRight(int id)
        {
            var socialRight = socialRightRepository.GetById(id);
            return socialRight;
        }
        public void CreateSocialRight(SocialRight socialRight)
        {
            socialRightRepository.Add(socialRight);
        }
        public void UpdateSocialRight(SocialRight socialRight)
        {
            socialRightRepository.Update(socialRight);
        }
        public void DeleteSocialRight(SocialRight socialRight)
        {
            socialRightRepository.Delete(socialRight);
        }
        public void SaveSocialRight()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
