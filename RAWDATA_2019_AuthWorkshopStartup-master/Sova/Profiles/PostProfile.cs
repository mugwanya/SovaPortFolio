using AutoMapper;
using SovaDataAccessLayer;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>();
       
        }
    }
}
