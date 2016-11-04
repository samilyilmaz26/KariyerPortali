using KariyerPortali.Admin.Models;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class UniversityController : Controller
    {
        // GET: Universities
        private readonly IUniversityService universityService;
        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }
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
            var allUniversities = universityService.Search(sSearch).ToList();
            IEnumerable<University> filteredUniversities = allUniversities;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["iSortCol_0"];
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0: filteredUniversities = filteredUniversities.OrderBy(u => u.UniversityId);
                        break;
                    case 1: filteredUniversities = filteredUniversities.OrderBy(u => u.UniversityName);
                        break;

                    default:
                        filteredUniversities = filteredUniversities.OrderBy(u => u.UniversityId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0: filteredUniversities = filteredUniversities.OrderByDescending(u => u.UniversityId);
                        break;
                    case 1: filteredUniversities = filteredUniversities.OrderByDescending(u => u.UniversityName);
                        break;

                    default:
                        filteredUniversities = filteredUniversities.OrderByDescending(u => u.UniversityId);
                        break;
                }
            }
            var displayedUniversities = filteredUniversities.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from u in displayedUniversities select new[] { u.UniversityId.ToString(), u.UniversityName.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecors = filteredUniversities.Count(),
                iTotalDisplayRecords = filteredUniversities.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}