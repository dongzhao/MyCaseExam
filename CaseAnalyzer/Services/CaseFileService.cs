using CaseAnalyzer.Config;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CaseAnalyzer.Services
{
    public class CaseFileService : IFileService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IFileConfig config;

        public CaseFileService(IFileConfig cfg) 
        {
            this.config = cfg;
        }
        /// <summary>
        /// To check if this is valid ZIP file
        /// </summary>
        public bool IsValidFile(string filePath)
        {
            try
            {
                var list = config.ValidFileExtNameList.Split(',').ToList();

                using (var zip = ZipFile.OpenRead(filePath))
                {
                    var entries = zip.Entries;
                    var extNameList = entries.Select(c => System.IO.Path.GetExtension(c.FullName).ToLower()).ToList();

                    // check any extension name is out of name list
                    var result = extNameList.Where(c => list.Any(d => d != c)).Count();
                    if (result > 0)
                    {
                        logger.Error("Invalid file included in the ZIP!");                        
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                logger.Error("Corrupted Zip file!" + e.StackTrace);
                return false;
            }
        }

        public string GetApplicationNumber(string filePath)
        {
            var appNumber = string.Empty;
            try
            {
                using (var zip = ZipFile.OpenRead(filePath))
                {
                    // get party.xml file
                    var entry = zip.Entries.Where(c => c.FullName.ToLower().EndsWith(".xml")).FirstOrDefault();
                    using (Stream s = entry.Open())
                    {
                        var doc = XDocument.Load(s);
                        var appElementName = config.CaseNumberXmlElementName;
                        appNumber = doc.Element("party").Element(appElementName).Value;
                    }
                }             
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace);
            }
            return appNumber;
        }

        public void ExtractFile(string filePath)
        {
            try
            {
                var appNo = GetApplicationNumber(filePath);
                var extractFolder = config.ExtractFolderPath + @"\" + appNo+"-"+Guid.NewGuid().ToString();
                Directory.CreateDirectory(extractFolder);
                ZipFile.ExtractToDirectory(filePath, extractFolder);
            }
            catch(Exception e)
            {
                logger.Error(e.StackTrace);
            }
        }

        public void ArchiveFile(string filePath)
        {
            // to archive the uploaded zip file 
            var archiveFolder = config.CaseFolderPath + @"\archive";
            if (!Directory.Exists(archiveFolder))
            {
                Directory.CreateDirectory(archiveFolder);
            }
            var archiveFilePath = archiveFolder + @"\" + Path.GetFileName(filePath);
            File.Move(filePath, archiveFilePath);
        }
    }
}
