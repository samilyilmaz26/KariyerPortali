using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class LanguageInfo
    {
        public int LanguageInfoId { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public LanguageLevel WritingLanguageLevel { get; set; }
        public LanguageLevel ReadingLanguageLevel { get; set; }
        public LanguageLevel SpeakingLanguageLevel { get; set; }
    }
}
