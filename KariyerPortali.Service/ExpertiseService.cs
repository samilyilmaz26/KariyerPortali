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
    public interface IExpertiseService
    {
        IEnumerable<Expertise> GetExpertises();
        Expertise GetExpertise(int id);
        void CreateExpertise(Expertise expertise);
        void UpdateExpertise(Expertise expertise);
        void DeleteExpertise(Expertise expertise);
        void SaveExpertise();
    }
    public class ExpertiseService : IExpertiseService
    {
        private readonly IExpertiseRepository expertiseRepository;
        private readonly IUnitOfWork unitOfWork;
        public ExpertiseService(IExpertiseRepository expertiseRepository, IUnitOfWork unitOfWork)
        {
            this.expertiseRepository = expertiseRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IExpertiseService Members
        public IEnumerable<Expertise> GetExpertises()
        {
            var expertises = expertiseRepository.GetAll();
            return expertises;
        }
        public Expertise GetExpertise(int id)
        {
            var expertise = expertiseRepository.GetById(id);
            return expertise;
        }
        public void CreateExpertise(Expertise expertise)
        {
            expertiseRepository.Add(expertise);
        }
        public void UpdateExpertise(Expertise expertise)
        {
            expertiseRepository.Update(expertise);
        }
        public void DeleteExpertise(Expertise expertise)
        {
            expertiseRepository.Delete(expertise);
        }
        public void SaveExpertise()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
