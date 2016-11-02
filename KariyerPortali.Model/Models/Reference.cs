using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Reference
    {
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public string ReferenceName { get; set; }
        public string ReferenceLastName { get; set; }
        public string EPosta { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public Sector Sector { get; set; }

        public string Message { get; set; }
        public string ReferenceFile { get; set; }

    }
}
