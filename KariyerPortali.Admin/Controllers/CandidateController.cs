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

        public ActionResult Edit()
        {
            return View();
        }
    }
}