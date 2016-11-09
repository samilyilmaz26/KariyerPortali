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
    public interface IFileService
    {
        IEnumerable<File> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

        IEnumerable<File> GetFiles();
        File GetFile(int id);
        void CreateFile(File file);
        void UpdateFile(File file);
        void DeleteFile(File file);
        void SaveFile();
    }
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepository;
        private readonly IUnitOfWork unitOfWork;
        public FileService(IFileRepository fileRepository, IUnitOfWork unitOfWork)
        {
            this.fileRepository = fileRepository;
            this.unitOfWork = unitOfWork;
        }
        #region IFileService Members

        public IEnumerable<File> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            var files = fileRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return files;
        }
        public IEnumerable<File> GetFiles()
        {
            var files = fileRepository.GetAll();
            return files;
        }
        public File GetFile(int id)
        {
            var file = fileRepository.GetById(id);
            return file;
        }
        public void CreateFile(File file)
        {
            fileRepository.Add(file);
        }
        public void UpdateFile(File file)
        {
            fileRepository.Update(file);
        }
        public void DeleteFile(File file)
        {
            fileRepository.Delete(file);
        }
        public void SaveFile()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
