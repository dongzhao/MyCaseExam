using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Services
{
    public interface IFileService
    {
        bool IsValidFile(string filePath);
        string GetApplicationNumber(string filePath);
        void ExtractFile(string filePath);
        void ArchiveFile(string filePath);
    }
}
