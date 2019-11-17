using AutoMapper;
using SovaDataAccessLayer;
using SovaWebAppicaltion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Profiles
{
    public class LinkPostProfile : Profile
    {
        public LinkPostProfile()
        {
            CreateMap<LinkPost, LinkPostDto>();

        }
    }
}
