using CaseAnalyzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Services
{
    public interface IEmailService
    {
        void Send(MailDto dto);
    }
}
