using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Domain.Constants.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadFileController : Controller
    {
        private readonly ISqlDbContext _DbContextRepository;
        private readonly IConfiguration _config;
        public DownloadFileController(ISqlDbContext DbContextRepository, IConfiguration config)
        {
            _DbContextRepository = DbContextRepository;
            _config = config;

        }


        [HttpGet("DownloadFileUnauthorize")]
        public IActionResult DownloadFileUnauthorize(string FilePath)
        {
            try
            {

                var _downloadDirectory = FilePathQueries.LmsFilepath;
                //var filePath = FilePath;
                var filePath = Path.Combine(_downloadDirectory, FilePath);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found");
                }

                var fileStream = System.IO.File.OpenRead(filePath);

                // Determine the MIME type of the file
                var contentType = "application/octet-stream"; // Default MIME type



                return File(fileStream, contentType, FilePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile(string FilePath)
        {
            try
            {

                //var _downloadDirectory = FilePathQueries.LmsFilepath;
                string? _downloadDirectory = "";

                _downloadDirectory = _config.GetSection("Development:urlName")?.Value;
                //var filePath = FilePath;
                var filePath = Path.Combine(_downloadDirectory, FilePath);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found");
                }

                var fileStream = System.IO.File.OpenRead(filePath);

                // Determine the MIME type of the file
                var contentType = "application/octet-stream"; // Default MIME type



                return File(fileStream, contentType, FilePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
