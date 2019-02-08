using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto;
using Library.Domain.Dto.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Library.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderBusiness _genderBusiness;

        public GenderController(IGenderBusiness genderBusiness)
        {
            _genderBusiness = genderBusiness;
        }

        [HttpGet("GetAllGenders")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _genderBusiness.GetAllGenders();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetGender/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _genderBusiness.GetGender(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddNewGender")]
        public async Task<IActionResult> AddGender([FromBody]GenderParameter gender)
        {
            try
            {
                var isAdded = await _genderBusiness.AddGender(gender);
                if (isAdded)
                    return Ok("Saved Successfully");
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateGender")]
        public async Task<IActionResult> UpdateGender([FromBody]GenderDto gender)
        {
            try
            {
                var isUpdated = await _genderBusiness.UpdateGender(gender);
                if (isUpdated)
                    return Ok("Saved Successfully");
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteGender/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _genderBusiness.DeleteGender(id);
                if (isDeleted)
                    return Ok("Deleted Successfully");
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
