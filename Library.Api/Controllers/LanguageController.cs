using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageBusiness _languageBusiness;

        public LanguageController(ILanguageBusiness languageBusiness)
        {
            _languageBusiness = languageBusiness;
        }

        [HttpGet("GetAllLanguages")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await _languageBusiness.GetAllLanguages();
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetLanguage/{id}")]
        public async Task<IActionResult> GetLanguage(int id)
        {
            var result = await _languageBusiness.GetLanguage(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost("AddNewLanguage")]
        public async Task<IActionResult> AddLanguage(LanguageParameter languageParameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _languageBusiness.AddLanguage(languageParameter);
                if (isAdded)
                {
                    var result = await _languageBusiness.GetAllLanguages();
                    return Ok(result);
                }

                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateOldLanguage")]
        public async Task<IActionResult> UpdateLanguage(LanguageDto language)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _languageBusiness.UpdateLanguage(language);
                if (isUpdated)
                {
                    var result = await _languageBusiness.GetAllLanguages();
                    return Ok(result);
                }

                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteLanguage/{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var isDeleted = await _languageBusiness.DeleteLanguage(id);
            if (isDeleted)
            {
                var result = await _languageBusiness.GetAllLanguages();
                return Ok(result);
            }
            return NoContent();
        }
    }
}