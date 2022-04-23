using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAnalyzer.Model
{
    public class MailDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public List<string> ToList { get; set; } = new List<string>();
        public List<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();
        public string SignatureUrl { get; set; }
    }

    public class AttachmentDto
    {
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FileContent { get; set; }
    }
}
