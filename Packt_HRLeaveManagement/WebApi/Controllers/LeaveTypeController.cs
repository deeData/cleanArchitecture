using Application.ClassLibrary.DTOs;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Commands;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Queries;
using Application.ClassLibrary.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get() 
        { 
            //mediatR sends a mediatR request (the request contains the data validations and biz logic so that it is no contained in the controller)
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandRepoonse>> Post([FromBody] LeaveTypeDto leaveType) 
        {
            //var response = await _mediator.Send(new CreateLeaveTypeCommand { LeaveTypeDto = leaveType });
            var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
        {
            await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType });
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return NoContent();
        }



    }
}
