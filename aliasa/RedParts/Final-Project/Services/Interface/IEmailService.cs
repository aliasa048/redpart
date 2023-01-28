using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services.Interface
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body, string from = null);
    }
}
