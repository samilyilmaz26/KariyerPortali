using AutoMapper;
using KariyerPortali.Model;
using KariyerPortali.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Mapper.CreateMap<Resume, ResumeViewModel>();
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}