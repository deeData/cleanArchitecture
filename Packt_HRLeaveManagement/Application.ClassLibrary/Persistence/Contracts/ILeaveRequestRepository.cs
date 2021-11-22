using Domain.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Persistence.Contracts
{
    //interface is specific to type LeaveRequest
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {

    }
}
