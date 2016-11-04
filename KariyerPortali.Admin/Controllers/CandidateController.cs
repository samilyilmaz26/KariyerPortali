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
        
            return View();

        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var allCandidates = candidateService.Search(sSearch).ToList();
            IEnumerable<Candidate> filteredCandidates = allCandidates;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                   
                    case 0:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.UserName);
                        break;
                        case 1:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.FirstName);
                        break;
                    case 2:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.LastName);
                        break;
                    case 3:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.Phone);
                        break;
                    case 4:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.Email);
                        break;
                    case 5:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.State);
                        break;
                    case 6:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.CreateDate);
                        break;
                    default:
                        filteredCandidates = filteredCandidates.OrderBy(c => c.UserName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredCandidates = filteredCandidates.OrderByDescending (c => c.UserName);
                        break;
                    case 1:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.FirstName);
                        break;
                    case 2:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.LastName);
                        break;
                    case 3:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.Phone);
                        break;
                    case 4:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.Email);
                        break;
                    case 5:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.State);
                        break;
                    case 6:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.CreateDate);
                        break;
                    default:
                        filteredCandidates = filteredCandidates.OrderByDescending(c => c.UserName);
                        break;
                }
            }

            var displayedCandidates = filteredCandidates.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCandidates
                         select new[] { c.UserName , c.FirstName + " " + c.LastName, c.Phone.ToString(), c.Email.ToString(), c.State.ToString(), c.CreateDate.ToShortDateString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allCandidates.Count(),
                iTotalDisplayRecords = filteredCandidates.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
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