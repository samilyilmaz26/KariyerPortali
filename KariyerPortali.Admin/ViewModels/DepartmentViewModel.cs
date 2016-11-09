using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "İşveren adı gereklidir.")]
        [DisplayName("Bölüm Adı")]
        public string DepartmentName { get; set; }
    }
}