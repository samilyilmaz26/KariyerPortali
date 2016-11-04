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
    public interface ICandidateService
    {
        IEnumerable<Candidate> Search(string search);
        IEnumerable<Candidate> GetCandidates();
        Candidate GetCandidate(int id);
        void CreateCandidate(Candidate candidate);
        void UpdateCandidate(Candidate candidate);
        void DeleteCandidate(Candidate candidate);
        void SaveCandidate();
    }
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IUnitOfWork unitOfWork;
        public CandidateService(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork)
        {
            this.candidateRepository = candidateRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICandidateService Members
        public IEnumerable<Candidate> GetCandidates()
        {
            var candidates = candidateRepository.GetAll();
            return candidates;
        }
        public Candidate GetCandidate(int id)
        {
            var candidate = candidateRepository.GetById(id);
            return candidate;
        }
        public void CreateCandidate(Candidate candidate)
        {
            candidateRepository.Add(candidate);
        }
        public void UpdateCandidate(Candidate candidate)
        {
            candidateRepository.Update(candidate);
        }
        public void DeleteCandidate(Candidate candidate)
        {
            candidateRepository.Delete(candidate);
        }
        public void SaveCandidate()
        {
            unitOfWork.Commit();
        }
        public IEnumerable<Candidate> Search(string search)
        {
            search = search.ToLower().Trim();
            var searchWords = search.Split(' ');


            var query = GetCandidates();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.UserName.Contains(sSearch) || c.FirstName.Contains(sSearch) || c.LastName.Contains(sSearch) || c.Photo.Contains(sSearch));
                }
            }
           
            return query;
        
        }
        #endregion
    }
}
