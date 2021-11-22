using Application.ClassLibrary.Persistence.Contracts;
using Domain.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ClassLibrary.Repositories
{
    //inherits implementation of GenericRepository relative to the LeaveType
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    
    }
}
