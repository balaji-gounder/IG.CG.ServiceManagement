using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace IG.CG.Core.Domain.Utility
{
    public class UploadDocument
    {
        readonly string[] permittedExtensions = { ".png", ".webp", ".svg", ".jpg", ".jpeg", ".gif", ".pdf", ".doc", ".xls", ".xlsx", ".csv", ".eml" };
        private readonly HttpRequest httpRequest;

        FilePathQueries objPath = new FilePathQueries();
        public UploadDocument(HttpRequest httpRequest)
        {
            this.httpRequest = httpRequest;
        }


        private readonly IConfiguration _config;

        private string GetAbsolutePath(string RelativePath)
        {
            Uri baseUri = new Uri($"{httpRequest.Scheme}://{httpRequest.Host.Value}");
            //if (httpRequest.Host.Value.ToLower().Equals("www.infintrixindia.com"))
            //{
            //    RelativePath = $"LabguruAPI/{RelativePath}";
            //}
            Uri UploadPath = new Uri(baseUri, RelativePath);
            return UploadPath.AbsoluteUri;
        }


        public string UploadImages1(List<IFormFile> files, DocumentTypes documents)
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

