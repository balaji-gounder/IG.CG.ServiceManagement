using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class TemplateMailAndSmsController : Controller
    {
        private readonly ILogger<TemplateMailAndSmsController> _logger;
        private readonly ITemplateMailAndSmsService _templateService;
        public TemplateMailAndSmsController(ITemplateMailAndSmsService templateService, ILogger<TemplateMailAndSmsController> logger)
        {
            _templateService = templateService;
            _logger = logger;
        }


        [HttpGet("GetAllTemplate")]
        public async Task<ActionResult<IEnumerable<TemplateMailAndSmsModel>>> GetTemplate([FromQuery] TemplateMailAndSmsFilter MSFilter)
        {
            var Template = await _templateService.GetAllTemplateAsync(MSFilter);


            if (Template is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Template);
            }
        }

        [HttpGet("GetTemplateById")]
        public async Task<ActionResult<TemplateMailAndSmsModel>> GetTemplateById(int templateId)
        {
            var Template = await _templateService.GetTemplateByIdAsync(templateId);
            if (Template is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Template);
            }
        }


        [HttpPost("UpsertTemplate")]
        public async Task<ActionResult> InsertTemplate(TemplateMailAndSmsModel temModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(temModel);
            }
            else
            {
                var template = await _templateService.UpsertTemplateAsync(temModel, User?.Identity?.Name);
                return Ok(template);
            }
        }


        [HttpDelete("DeleteTemplate")]
        public async Task<ActionResult> RemoveTemplate(int templateId, int isActive)
        {
            var template = await _templateService.DeleteTemplateAsync(templateId, User?.Identity?.Name, isActive);
            return Ok(template);
        }

    }
}
