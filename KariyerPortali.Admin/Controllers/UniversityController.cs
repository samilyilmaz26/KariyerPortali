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
            ViewBag.UniversityId = new SelectList(universityService.GetUniversities(), "UniversityId", "UniversityName");
            return View();
            
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"];
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedUniversities = universityService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            var result = from u in displayedUniversities select new[] { string.Empty, u.UniversityId.ToString(), u.UniversityName.ToString() };
            
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}