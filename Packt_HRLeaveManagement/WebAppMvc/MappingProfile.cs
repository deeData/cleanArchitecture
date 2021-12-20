using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvc.Models;
using WebAppMvc.Services.Base;

namespace WebAppMvc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
