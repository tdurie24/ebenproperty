using System;
using System.Collections.Generic;
using System.Text;
using Eben.Business.Models;

namespace Eben.Business.Contracts
{
    public interface IEmailService
    {
        bool SendEmail(ContactModel contact);
    }
}
