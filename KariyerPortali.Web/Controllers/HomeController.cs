using AutoMapper;
using KariyerPortali.Model;
using KariyerPortali.Service;
using KariyerPortali.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResumeService cvService;

        public HomeController(IResumeService resumeService)
        {
            this.cvService = resumeService;
        }

        public ActionResult Index()
        {
            IEnumerable<ResumeViewModel> viewModelCvs;
            IEnumerable<Resume> cvs;

            cvs = cvService.GetResumes().ToList();

            viewModelCvs = Mapper.Map<IEnumerable<Resume>, IEnumerable<ResumeViewModel>>(cvs);

            return View(viewModelCvs);
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