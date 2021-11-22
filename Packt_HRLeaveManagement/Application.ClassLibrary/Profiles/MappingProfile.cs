using Application.ClassLibrary.DTOs;
using Application.ClassLibrary.DTOs.LeaveRequest;
using AutoMapper;
using Domain.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Profiles
{
    public class MappingProfile : Profile
    {
        //constructor
        public MappingProfile() 
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
