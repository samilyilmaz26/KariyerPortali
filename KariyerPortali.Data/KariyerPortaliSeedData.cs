using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data
{
    public class KariyerPortaliSeedData : DropCreateDatabaseIfModelChanges<KariyerPortaliEntities>
    {
        protected override void Seed(KariyerPortaliEntities context)
        {
            //GetResumes().ForEach(c => context.Resumes.Add(c));

            context.Commit();
        }

        private static List<Resume> GetResumes()
        {
            return new List<Resume>
            {
                new Resume {
                    ResumeName = "Murat Demirci"
                },
                new Resume {
                    ResumeName = "Şamil Yılmaz"
                }
            };
        }

    }
}
