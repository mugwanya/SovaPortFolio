using AutoMapper;
using SovaDataAccessLayer.FrameworkTables;
using SovaWebAppicaltion.Model;
using SovaWebAppicaltion.Model.FrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Profiles
{
    public class MarkingsProfile : Profile
    {
        public MarkingsProfile()
        {
            CreateMap<Marking, MarkingsDto>();
            CreateMap<MarkingForCreation, Marking>();
        }
    }
}
