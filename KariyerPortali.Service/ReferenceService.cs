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
    public interface IReferenceService
    {
        IEnumerable<Reference> GetReferences();
        Reference GetReference(int id);
        void CreateReference(Reference reference);
        void UpdateReference(Reference reference);
        void DeleteReference(Reference reference);
        void SaveReference();
    }
    public class ReferenceService : IReferenceService
    {
        private readonly IReferenceRepository referenceRepository;
        private readonly IUnitOfWork unitOfWork;
        public ReferenceService(IReferenceRepository referenceRepository, IUnitOfWork unitOfWork)
        {
            this.referenceRepository = referenceRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IReferenceService Members
        public IEnumerable<Reference> GetReferences()
        {
            var references = referenceRepository.GetAll();
            return references;
        }
        public Reference GetReference(int id)
        {
            var reference = referenceRepository.GetById(id);
            return reference;
        }
        public void CreateReference(Reference reference)
        {
            referenceRepository.Add(reference);
        }
        public void UpdateReference(Reference reference)
        {
            referenceRepository.Update(reference);
        }
        public void DeleteReference(Reference reference)
        {
            referenceRepository.Delete(reference);
        }
        public void SaveReference()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
