using AutoMapper;
using SovaDataAccessLayer.FrameworkTables;
using SovaWebAppicaltion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Notes, NoteDto>();
            CreateMap<NoteForCreation, Notes>();
        }
    }
}
