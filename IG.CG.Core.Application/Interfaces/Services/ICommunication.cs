using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ICommunication
    {
        public Task<Tuple<bool, string>?> SendSMS(SMSModel smsModel);
        public Task<Tuple<bool, string>?> SendEmail(EmailModel emailModel);
        public Task<List<Tuple<bool, string>>> UploadDocument(List<IFormFile> files, DocumentTypes documents);

    }
}
