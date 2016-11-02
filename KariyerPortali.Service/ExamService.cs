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
    public interface IExamService
    {
        IEnumerable<Exam> GetExams();
        Exam GetExam(int id);
        void CreateExam(Exam exam);
        void SaveExam();
    }
    public class ExamService:IExamService
    {
        private readonly IExamRepository examRepository;
        private readonly IUnitOfWork unitOfWork;
        public ExamService(IExamRepository examRepository, IUnitOfWork unitOfWork)
        {
            this.examRepository = examRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IExamService Members
        public IEnumerable<Exam> GetExams()
        {
            var exams = examRepository.GetAll();
            return exams;
        }
        public Exam GetExam(int id)
        {
            var exam = examRepository.GetById(id);
            return exam;
        }
        public void CreateExam(Exam exam)
        {
            examRepository.Add(exam);
        }
        public void SaveExam()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
