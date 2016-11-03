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
    public class CandidateController : Controller
    {
        
        private readonly ICandidateService candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }
        // GET: Candidate
        public ActionResult Index()
        {
            IEnumerable<CandidateViewModel> viewModelCandidate;

            IEnumerable<Candidate> candidate;

            candidate = candidateService.GetCandidates().ToList();

            viewModelCandidate = Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateViewModel>>(candidate);

            return View(viewModelCandidate);

        }

        //public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        //{

        //    string sSearch = "";
        //    if (param.sSearch != null) sSearch = param.sSearch;
        //    var allCandidates = new CandidateService().GetAllCandidates(sSearch);
        //    IEnumerable<Candidate> filteredCandidates = allCandidates;

        //    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


        //    var sortDirection = Request["sSortDir_0"]; // asc or desc
        //    if (sortDirection == "asc")
        //    {
        //        switch (sortColumnIndex)
        //        {
        //            case 0:
        //                filteredCandidates = filteredCandidates.OrderBy(c => c.CandidateId);
        //                break;
        //            case 1:
        //                filteredCandidates = filteredCandidates.OrderBy(c => c.UserName);
        //                break;

        //            default:
        //                filteredCandidates = filteredCandidates.OrderBy(c => c.CandidateId);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (sortColumnIndex)
        //        {
        //            case 0:
        //                filteredCandidates = filteredCandidates.OrderByDescending(c => c.CandidateId);
        //                break;
        //            case 1:
        //                filteredCandidates = filteredCandidates.OrderByDescending(c => c.UserName);
        //                break;

        //            default:
        //                filteredCandidates = filteredCandidates.OrderByDescending(c => c.CandidateId);
        //                break;
        //        }
        //    }

        //    var displayedCVs = filteredCandidates.Skip(param.iDisplayStart).Take(param.iDisplayLength);
        //    var result = from c in displayedCVs
        //                 select new[] { c.UserName ?? string.Empty, c.FirstName + " " + c.LastName, c.Phone.ToString(), c.State.ToString(), c.Email.ToString(), c.CreateDate.ToShortDateString() };
        //    return Json(new
        //    {
        //        sEcho = param.sEcho,
        //        iTotalRecords = allCandidates.Count(),
        //        iTotalDisplayRecords = filteredCandidates.Count(),
        //        aaData = result
        //    },
        //        JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}