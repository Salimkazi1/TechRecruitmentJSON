using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TechRecruitmentJson.Infrastructure.Helpers;
using TechRecruitmentJson.Models;
using TechRecruitmentJson.Service.Interfaces;

namespace TechRecruitmentJson.Controllers
{
    [ApiController]
    [Route("api/schema/[controller]")]
    public class ValidatorController : ControllerBase
    {

        private readonly ILogger<ValidatorController> _logger;
        private readonly IJsonValidatorService jsonValidatorService;

        public ValidatorController(
            ILogger<ValidatorController> logger,
            IJsonValidatorService jsonValidatorService)
        {
            _logger = logger;
            this.jsonValidatorService = jsonValidatorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">Contains the json to validate</param>
        /// <returns></returns>
        [HttpPost("validate", Name = "ValidateJson")]
        public ActionResult<ValidateResponse> Validate(ValidationRequest request)
        {
            try
            {
                var response = this.jsonValidatorService.Validate(request.Json.ToString(), request.DataModelShema?.ToString());
                return response;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelFile"> The json file to validate</param>
        /// <param name="modelSchemaFile"> The json schema to validate against</param>
        /// <returns></returns>
        [HttpPost("validate/files", Name = "ValidateJsonFile")]
        public ActionResult<ValidateResponse> Validate(IFormFile modelFile, IFormFile modelSchemaFile)
        {

            try
            {
                var json = modelFile.ReadAsString();
                var dataModelSchema = modelSchemaFile.ReadAsString();

                var response = this.jsonValidatorService.Validate(json, dataModelSchema);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
