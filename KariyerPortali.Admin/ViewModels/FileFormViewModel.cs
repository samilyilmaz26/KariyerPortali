using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KariyerPortali.Admin.ViewModels
{
    public class FileFormViewModel
    {
        public int FileId { get; set; }
        [DisplayName("Dosya Adı")]
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }

    }
}