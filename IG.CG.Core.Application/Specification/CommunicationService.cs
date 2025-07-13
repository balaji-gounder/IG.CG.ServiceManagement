using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Xml;


namespace IG.CG.Core.Application.Specification
{
    public class CommunicationService : ICommunication
    {
        private readonly IConfiguration _config;
        readonly string[] permittedExtensions = { ".png", ".jpg", ".jpeg", ".pdf", ".doc", ".docx" };

        public CommunicationService(IConfiguration config)
        {
            _config = config;
        }
        private static readonly HttpClient client = new HttpClient();



        public async Task<Tuple<bool, string>?> SendSMS(SMSModel smsModel)
        {
            Tuple<bool, string>? retValue = null;
            try
            {
                string? serviceURL = _config.GetSection("SMSConfig:SMSBaseUrl")?.Value;
                string? Password = _config.GetSection("SMSConfig:SMSPassword")?.Value;
                string? UserId = _config.GetSection("SMSConfig:SMSUserId")?.Value;

                string strURL = serviceURL + "&username=" + UserId
                            + "&password=" + Password
                            + "&To=" + smsModel.ToNumber
                            + "&Text=" + smsModel.SmsBody
                            + "&time=&senderid=CGL";


                HttpResponseMessage response = await client.GetAsync(strURL);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseContent);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                dynamic jsonObj = JsonConvert.DeserializeObject(jsonText);

                string reqId = jsonObj["RESULT"]["@REQID"];
                string submitDate = jsonObj["RESULT"]["MID"]["@SUBMITDATE"];
                string midTid = jsonObj["RESULT"]["MID"]["@TID"];



                retValue = responseContent != null ? DecodeXML(responseContent) : null;
            }
            catch
            {
                throw;
            }
            return retValue;
        }



        private Tuple<bool, string>? DecodeXML(string xmlData)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData);
            XmlNode? ErrorcodeNode = xmlDoc.SelectSingleNode("//RESULT/REQUEST-ERROR/ERROR/CODE");
            XmlNode? ErrordescNode = xmlDoc.SelectSingleNode("//RESULT/REQUEST-ERROR/ERROR/DESC");
            XmlNode? resultNode = xmlDoc.SelectSingleNode("//RESULT");

            if (ErrorcodeNode is not null && ErrordescNode is not null)
            {
                return new Tuple<bool, string>(false, ErrorcodeNode.InnerText + "-" + ErrordescNode.InnerText);
            }
            else if (resultNode is not null)
            {
                return new Tuple<bool, string>(true, "SUCCESS");
            }
            else
            {
                return null;
            }
        }
        public async Task<Tuple<bool, string>?> SendEmail(EmailModel emailModel)
        {
            try
            {
                // get email server config settings from appsettings.json
                string? smtpServer = _config["EmailConfig:SmtpServer"];
                int smtpPort = int.Parse(_config["EmailConfig:SmtpPort"]);
                string? smtpUsername = _config["EmailConfig:Username"];
                string? smtpPassword = _config["EmailConfig:Password"];

                // construct email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress(smtpUsername);
                message.To.Add(emailModel.ToMail);
                message.Subject = emailModel.Subject;
                message.Body = emailModel.MailBody;

                // send the email using SMTP client
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    client.EnableSsl = true;
                    await client.SendMailAsync(message);
                }

                return new Tuple<bool, string>(true, "SUCCESS");

            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);

            }
        }

        public async Task<List<Tuple<bool, string>>> UploadDocument(List<IFormFile> files, DocumentTypes documents)
        {

            List<Tuple<bool, string>> UploadedFilesPath = new List<Tuple<bool, string>>();

            if (files?.Count > 0)
            {
                string DFolder = string.Empty;
                if (DocumentTypes.LmsDocument == documents)
                    DFolder = "LmsDocument";
                else if (DocumentTypes.Document == documents)
                    DFolder = "Document";
                else if (DocumentTypes.InvoiceDocument == documents)
                    DFolder = "InvoiceDocument";
                else if (DocumentTypes.FIRDocument == documents)
                    DFolder = "FIRDocument";
                else if (DocumentTypes.KnowledeDoc == documents)
                    DFolder = "KnowledeDoc";
                else
                    DFolder = "TempFolder";


                foreach (var formFile in files)
                {
                    var ext = Path.GetExtension(formFile.FileName).ToLowerInvariant();
                    if (!permittedExtensions.Contains(ext))
                    {
                        UploadedFilesPath.Add(new Tuple<bool, string>(false, "Invalid File Extension " + formFile.FileName));
                        files.Remove(formFile);
                    }
                }

                string? urlName = "";
                urlName = _config.GetSection("Development:urlName")?.Value;

                string uploadPath = Path.Combine(urlName, DFolder);

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {


                        string fileName = string.Format("{0:yyMMddHHmmss}", DateTime.Now) + "_" + ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');


                        string filePath = Path.Combine(uploadPath, fileName);
                        string dbPath = Path.Combine(DFolder, fileName);

                        try
                        {
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                await formFile.CopyToAsync(stream);
                                UploadedFilesPath.Add(new Tuple<bool, string>(true, dbPath));

                            }
                        }
                        catch (Exception ex)
                        {
                            UploadedFilesPath.Add(new Tuple<bool, string>(false, "File upload failed for " + formFile.FileName + " " + ex.Message)); // Store failure status and exception message
                        }

                    }

                }
            }
            return UploadedFilesPath;
        }


        public string UploadImagesOnlyone(List<IFormFile> files, DocumentTypes documents)
        {
            string UploadedFilesPath = "";
            if (files?.Count > 0)
            {
                string DFolder = string.Empty;
                if (DocumentTypes.LmsDocument == documents)
                    DFolder = "LmsDocument";
                else if (DocumentTypes.Document == documents)
                    DFolder = "Document";
                else if (DocumentTypes.InvoiceDocument == documents)
                    DFolder = "InvoiceDocument";
                else
                    DFolder = "TempFolder";

                //  List<string> UploadedFilesPath = new List<string>();
                //long size = files.Sum(f => f.Length);
                //string UploadedFilesPath = "";
                foreach (var formFile in files)
                {
                    var ext = Path.GetExtension(formFile.FileName).ToLowerInvariant();
                    if (!permittedExtensions.Contains(ext))
                        throw new Exception("Invalid File Extension : " + ext);
                }


                var folderName = Path.Combine("Document", DFolder);
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var path1 = "";


                        path1 = FilePathQueries.LmsFilepath;


                        var pathToSave = Path.Combine(path1, DFolder);

                        // var pathToSave = "";
                        var fileName = string.Format("{0:yyMMddHHmmss}", DateTime.Now) + "_" + ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');


                        var dbPath = Path.Combine(DFolder, fileName);

                        var filePath = Path.Combine(pathToSave, fileName);


                        using (var stream = System.IO.File.Create(filePath))
                        {
                            // UploadedFilesPath.Add(GetAbsolutePath(dbPath));
                            UploadedFilesPath = dbPath;
                            formFile.CopyTo(stream);
                        }
                    }

                }
            }
            return UploadedFilesPath;
        }




    }
}
