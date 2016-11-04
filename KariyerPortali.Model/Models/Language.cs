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
        public virtual ICollection<LanguageInfo> LanguageInfos { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }
}
