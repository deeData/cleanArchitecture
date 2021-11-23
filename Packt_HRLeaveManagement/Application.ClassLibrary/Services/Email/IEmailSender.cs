﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Services.Email
{
    //send email notifications on status of leave requests
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
