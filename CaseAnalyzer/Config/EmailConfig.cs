using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Config
{
    public class EmailConfig : IEmailConfig
    {
        private NameValueCollection settings;

        public EmailConfig()
        {
            this.settings = ConfigurationManager.GetSection("email") as NameValueCollection;
        }

        public string Host
        {
            get { return Convert.ToString(settings["host"]); }
        }

        public int Port
        {
            get { return Convert.ToInt32(settings["port"]); }
        }

        public string Username
        {
            get { return Convert.ToString(settings["username"]); }
        }

        public string Password
        {
            get { return Convert.ToString(settings["password"]); }
        }
    }
}
