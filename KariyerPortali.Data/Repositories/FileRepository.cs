using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Repositories
{
    public class FileRepository : RepositoryBase<File>, IFileRepository
    {
        public FileRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<File> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords)
        {
            search = search.Trim();
            var searchWords = search.Split(' ');


            var query = this.DbContext.Files.AsQueryable();
            foreach (string sSearch in searchWords)
            {
                if (sSearch != null && sSearch != "")
                {
                    query = query.Where(c => c.FileName.Contains(sSearch) || c.CreatedBy.Contains(sSearch) || c.CreateDate.ToString().Contains(sSearch) || c.UpdatedBy.Contains(sSearch) || c.UpdateDate.ToString().Contains(sSearch));
                }
            }

            var allFiles = query;

            IEnumerable<File> filteredFiles = allFiles;





            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredFiles = filteredFiles.OrderBy(c => c.FileName);
                        break;
                    case 1:
                        filteredFiles = filteredFiles.OrderBy(c => c.CreatedBy);
                        break;
                    case 2:
                        filteredFiles = filteredFiles.OrderBy(c => c.CreateDate);
                        break;
                    case 3:
                        filteredFiles = filteredFiles.OrderBy(c => c.UpdatedBy);
                        break;

                    default:
                        filteredFiles = filteredFiles.OrderBy(c => c.UpdateDate);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredFiles = filteredFiles.OrderByDescending(c => c.FileName);
                        break;
                    case 1:
                        filteredFiles = filteredFiles.OrderByDescending(c => c.CreatedBy);
                        break;
                    case 2:
                        filteredFiles = filteredFiles.OrderByDescending(c => c.CreateDate);
                        break;
                    case 3:
                        filteredFiles = filteredFiles.OrderByDescending(c => c.UpdatedBy);
                        break;

                    default:
                        filteredFiles = filteredFiles.OrderByDescending(c => c.UpdateDate);
                        break;
                }
            }

            var displayedFiles = filteredFiles.Skip(displayStart).Take(displayLength);

            totalRecords = allFiles.Count();
            totalDisplayRecords = filteredFiles.Count();
            return displayedFiles.ToList();
        }
    }
    public interface IFileRepository : IRepository<File>
    {
        IEnumerable<File> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);

    }
}
