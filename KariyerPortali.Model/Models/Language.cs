using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Language

    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public ICollection<LanguageInfo> LanguageInfos { get; set; }
        public ICollection<Resume> Resumes { get; set; }
    }
}
