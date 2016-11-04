using AutoMapper;
using KariyerPortali.Admin.Models;
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
 
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var allLanguages = languageService.Search(sSearch).ToList();
            IEnumerable<Language> filteredLanguages = allLanguages;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredLanguages = filteredLanguages.OrderBy(l => l.LanguageId);
                        break;
                    case 1:
                        filteredLanguages = filteredLanguages.OrderBy(l => l.LanguageName);
                        break;

                    default:
                        filteredLanguages = filteredLanguages.OrderBy(l => l.LanguageId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredLanguages = filteredLanguages.OrderByDescending(l => l.LanguageId);
                        break;
                    case 1:
                        filteredLanguages = filteredLanguages.OrderByDescending(l => l.LanguageName);
                        break;

                    default:
                        filteredLanguages = filteredLanguages.OrderByDescending(l => l.LanguageId);
                        break;
                }
            }

            var displayedLanguages = filteredLanguages.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from l in displayedLanguages
                         select new[] { l.LanguageId.ToString() ?? l.LanguageName.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allLanguages.Count(),
                iTotalDisplayRecords = filteredLanguages.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}