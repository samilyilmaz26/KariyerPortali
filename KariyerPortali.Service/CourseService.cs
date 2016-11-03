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
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
        void SaveCourse();
    }
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICourseService Members
        public IEnumerable<Course> GetCourses()
        {
            var courses = courseRepository.GetAll();
            return courses;
        }
        public Course GetCourse(int id)
        {
            var course = courseRepository.GetById(id);
            return course;
        }
        public void CreateCourse(Course course)
        {
            courseRepository.Add(course);
        }
        public void UpdateCourse(Course course)
        {
            courseRepository.Update(course);
        }
        public void DeleteCourse(Course course)
        {
            courseRepository.Delete(course);
        }
        public void SaveCourse()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}