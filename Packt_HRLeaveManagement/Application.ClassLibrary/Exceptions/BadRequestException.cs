using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        //also pass the message into the base clasee ApplicationException
        public BadRequestException(string message) : base(message)
        {
                
        }
    }
}
