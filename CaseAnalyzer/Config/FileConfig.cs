using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Config
{
    public class FileConfig : IFileConfig
    {
        private NameValueCollection settings;

        public FileConfig()
        {
            this.settings = ConfigurationManager.GetSection("casefile") as NameValueCollection;
        }

        public string CaseFolderPath
        {
            get { return Convert.ToString(settings["case.folder.path"]); }
        }
        public string ExtractFolderPath
        {
            get { return Convert.ToString(settings["extract.folder.path"]); }
        }

        public string AdminEmail
        {
            get { return Convert.ToString(settings["admin.email"]); }
        }

        public string ValidFileExtNameList
        {
            get { return Convert.ToString(settings["file.extension.name"]); }
        }
        public string CaseNumberXmlElementName
        {
            get { return Convert.ToString(settings["case.number.element.name"]); }
        }
        
    }
}
