using CaseAnalyzer.Config;
using CaseAnalyzer.Model;
using CaseAnalyzer.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer
{
    public class Analyzer : IAnalyzer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IFileService fileService;
        private readonly IEmailService emailService;
        private readonly IFileConfig config;

        public Analyzer(IFileService fs, IEmailService es, IFileConfig cfg)
        {
            this.fileService = fs;
            this.emailService = es;
            this.config = cfg;  
        }

        public void StartProcess()
        {
            try
            {
                var caseFolder = config.CaseFolderPath;

                var files = Directory.GetFiles(caseFolder);
                foreach (var file in files)
                {
                    var valid = fileService.IsValidFile(file);
                    if (valid)
                    {
                        fileService.ExtractFile(file);
                        var dto = new MailDto()
                        {
                            Subject = "Uploaded file has been dispatched!",
                            Body = "Hi Admin.....", // to do: read from Email Template
                        };
                        dto.ToList.Add(config.AdminEmail);
                        emailService.Send(dto);
                    }
                    else
                    {
                        var dto = new MailDto()
                        {
                            Subject = "Uploaded file is Invalid!",
                            Body = "Hi Admin.....", // to do: read from Email Template
                        };
                        dto.ToList.Add(config.AdminEmail);
                        emailService.Send(dto);
                    }
                    fileService.ArchiveFile(file);
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            
        }
    }
}
