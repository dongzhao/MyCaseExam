using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Config
{
    public interface IFileConfig
    {
        string CaseFolderPath { get; }
        string ExtractFolderPath { get; }
        string AdminEmail { get; }
        string ValidFileExtNameList { get; }
        string CaseNumberXmlElementName { get; }
    }
}
