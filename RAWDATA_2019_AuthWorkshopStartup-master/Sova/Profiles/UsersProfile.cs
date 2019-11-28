using AutoMapper;
using SovaDataAccessLayer.QATables;
using SovaWebAppicaltion.Model;
using SovaWebAppicaltion.Model.FrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<SovaDataAccessLayer.FrameworkTables.User, UsersDto>();
            CreateMap<UsersForCreation, SovaDataAccessLayer.FrameworkTables.User>();

        }
    }
}
