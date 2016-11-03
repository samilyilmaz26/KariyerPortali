using AutoMapper;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }
        
        // GET: Language
        public ActionResult Index()
        {
            IEnumerable<LanguageViewModel> viewModelLanguage;

            IEnumerable<Language> language;

            language = languageService.GetLanguages().ToList();

            viewModelLanguage = Mapper.Map<IEnumerable<Language>, IEnumerable<LanguageViewModel>>(language);

            return View(viewModelLanguage);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}