using Application.ClassLibrary.DTOs;
using Application.ClassLibrary.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Features.LeaveTypes.Requests.Commands
{
    //return id after LeaveType is created
    public class CreateLeaveTypeCommand : IRequest<BaseCommandRepoonse>
    {
        //consumer will send over from request
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
