using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Config
{
    public interface IEmailConfig
    {
        string Host { get; }
        int Port { get; }
        string Password { get; }
        string Username { get; }
    }
}
