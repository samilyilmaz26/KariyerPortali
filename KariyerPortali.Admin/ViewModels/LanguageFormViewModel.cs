using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class LanguageFormViewModel
    {
        public int LanguageId { get; set; }
        [DisplayName("Dil Adı")]
        public string LanguageName { get; set; }
    }
}