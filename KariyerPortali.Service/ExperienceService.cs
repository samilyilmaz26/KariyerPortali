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
    public interface IExperienceService
    {
        IEnumerable<Experience> GetExperiences();
        Experience GetExperience(int id);
        void CreateExperience(Experience experience);
        void UpdateExperience(Experience experience);
        void DeleteExperience(Experience experience);
        void SaveExperience();
    }
    public class ExperienceService:IExperienceService
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly IUnitOfWork unitOfWork;
        public ExperienceService(IExperienceRepository experienceRepository, IUnitOfWork unitOfWork)
        {
            this.experienceRepository = experienceRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IExperienceService Members
        public IEnumerable<Experience> GetExperiences()
        {
            var experiences = experienceRepository.GetAll();
            return experiences;
        }
        public Experience GetExperience(int id)
        {
            var experience = experienceRepository.GetById(id);
            return experience;
        }
        public void CreateExperience(Experience experience)
        {
            experienceRepository.Add(experience);
        }
        public void UpdateExperience(Experience experience)
        {
            experienceRepository.Update(experience);
        }
        public void DeleteExperience(Experience experience)
        {
            experienceRepository.Delete(experience);
        }
        public void SaveExperience()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
