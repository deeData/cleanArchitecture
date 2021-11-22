using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //can use nameof() to get string name of that object for input param at instantiation/execution4
        //example throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found.")
        {

        }
    }
}
