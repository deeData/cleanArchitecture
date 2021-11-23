using Application.ClassLibrary.DTOs.LeaveRequest;
using Application.ClassLibrary.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Features.LeaveRequests.Requests.Commands
{
    class CreateLeaveRequestCommand : IRequest<BaseCommandRepoonse>
    {
        //request includes this dto
        public LeaveRequestDto LeaveRequestDto { get; set; }
    }
}
