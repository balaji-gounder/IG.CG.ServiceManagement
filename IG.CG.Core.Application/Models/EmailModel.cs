using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class EmailModel
    {
        public string? ToMail { get; set; }
        public string? Subject { get; set; }
        public string? MailBody { get; set; }
    }
}
