using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IG.CG.Core.Application.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using IG.CG.Core.Application.Interfaces.Services;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class PincodeMappingUserController : ControllerBase
    {
        private readonly ILogger<PincodeMappingUserController> _logger;
        private readonly IPincodeMappingUserRepository _pincodeMappingUserRepository;
        private readonly IPincodeMappingUserService _pincodeMappingUserService;
        private readonly List<string> _expectedKeys = new List<string>
        {
            "Pincode",
            "District",
            "TalukaName",
            "Branch",
            "ASCDistance",
            "MapFor",
            "PartnerName"
        };

        public PincodeMappingUserController(IPincodeMappingUserRepository pincodeMappingUserRepository,IPincodeMappingUserService pincodeMappingUserService, ILogger<PincodeMappingUserController> logger)
        {
            _pincodeMappingUserRepository = pincodeMappingUserRepository;
            _pincodeMappingUserService = pincodeMappingUserService;
            _logger = logger;
        }
      

        [HttpPost("AddPincodeMappingUser")]
        public async Task<IActionResult> PostJsonData([FromBody] List<PincodeMappingUserModel> lstPincodeMappingUser)
        {
            if (lstPincodeMappingUser == null || !lstPincodeMappingUser.Any())
            {
                return BadRequest("No JSON data provided.");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var errors = new List<object>();

            var pincodeMappingUserItem = lstPincodeMappingUser[0];
            var missingKeys = ValidateJsonStructure(pincodeMappingUserItem);
            if (missingKeys.Any())
            {
                 errors.Add(new
                 {
                     Item = pincodeMappingUserItem,
                     MissingKeys = missingKeys,
                 });
            }
            
            if (errors.Any())
            {
                return BadRequest(errors);
            }

            string jsonData;
            try
            {
                jsonData = JsonConvert.SerializeObject(lstPincodeMappingUser);
            }
            catch (JsonException ex)
            {
                return BadRequest("Invalid JSON format. Error: " + ex.Message);
            }

            int? result = 0;
            result = await _pincodeMappingUserRepository.AddPincodeMappingUser(jsonData);

            return Ok(result);
        }


        private List<string>  ValidateJsonStructure(PincodeMappingUserModel pincodeMappingUser)
        {

            var jsonProperties = pincodeMappingUser.GetType().GetProperties().Select(p => p.Name).ToList();
            var missingKeys = _expectedKeys.Where(key => !jsonProperties.Contains(key) || pincodeMappingUser.GetType().GetProperty(key)?.GetValue(pincodeMappingUser) == null).ToList();

            return (missingKeys);
        }

        [HttpGet("GetAllPincodeMappingUser")]
        public async Task<ActionResult<IEnumerable<PincodeMappingUserDisplayModel>>> GetPincodeMappingUser([FromQuery] BaseFilter baseFilter)
        {
            var PincodeMappingUser = await _pincodeMappingUserService.GetAllPincodeMappingUserAsync(baseFilter);

            if (PincodeMappingUser is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(PincodeMappingUser);
            }
        }
    }
}
