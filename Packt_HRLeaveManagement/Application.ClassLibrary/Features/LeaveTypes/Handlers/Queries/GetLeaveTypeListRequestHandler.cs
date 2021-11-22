using Application.ClassLibrary.DTOs;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Queries;
using Application.ClassLibrary.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Features.LeaveTypes.Handlers.Queries
{
    //to handle GetLeaveTypeRequest and return list of LeaveTypeDto
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        //implement MediatR's IRequestHandler
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveRequestRepository.GetAllAsync();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }




    }
}
