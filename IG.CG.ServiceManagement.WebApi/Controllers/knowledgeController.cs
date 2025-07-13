using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class knowledgeController : Controller
    {
        private readonly ILogger<knowledgeController> _logger;
        private readonly IknowledgeService _KwService;
        public knowledgeController(IknowledgeService KwService, ILogger<knowledgeController> logger)
        {
            _KwService = KwService;
            _logger = logger;

        }


        [HttpGet("GetAllknowledge")]
        public async Task<ActionResult<IEnumerable<knowledgelistModel>>> GetAllknowledgeAsync()
        {
            var Region = await _KwService.GetAllknowledgeAsync(User?.Identity?.Name);
            if (Region is null)
            {

                return NotFound();

            }
            else
            {

                return Ok(Region);

            }
        }



        [HttpGet("GetknowledgeById")]
        public async Task<ActionResult<knowledgelistModel>> GetknowledgeByIdAsync(string? knowledgeId)
        {
            var Region = await _KwService.GetknowledgeByIdAsync(knowledgeId);
            if (Region is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Region);

            }

        }



        //[HttpPost("Upsertknowledge")]
        //public async Task<ActionResult> UpsertknowledgeAsync([FromForm] knowledgeModel KwModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return UnprocessableEntity(ModelState);
        //    }
        //    else
        //    {
        //        var region = await _KwService.UpsertknowledgeAsync(KwModel, User?.Identity?.Name);
        //        return Ok(region);
        //    }
        //}




        [HttpPost("Upsertknowledge")]
        public async Task<ActionResult> UpsertknowledgeAsync([FromForm] knowledgeInfoDetailslistModel KwModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var asc = await _KwService.UpsertknowledgeAsync(KwModel, User?.Identity?.Name);
                return Ok(asc);

            }

        }









        [HttpDelete("Deleteknowledge")]
        public async Task<ActionResult> DeleteknowledgeAsync(string? knowledgeId, int isActive)
        {
            var region = await _KwService.DeleteknowledgeAsync(knowledgeId, User?.Identity?.Name, isActive);
            return Ok(region);
        }



    }
}
