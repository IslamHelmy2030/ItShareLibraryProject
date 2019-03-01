using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Business.Interfaces;
using Library.Domain.Dto.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorBusiness _authorBusiness;

        public AuthorController(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var result = await _authorBusiness.GetAllAuthors();
            if (result.Any()) return Ok(result);
            return NotFound();
        }

        [HttpGet("GetAuthor/{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var result = await _authorBusiness.GetAuthor(id);
            if (result!= null) return Ok(result);
            return NotFound();
        }

        [HttpPost("AddNewAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody]AddAuthorParameter author)
        {
            var isAdded = await _authorBusiness.AddAuthor(author);
            if (isAdded) return Ok("Saved Successfully");
            return NoContent();
        }

        [HttpPut("UpdateOldAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody]UpdateAuthorParameter author)
        {
            var isUpdated = await _authorBusiness.UpdateAuthor(author);
            if (isUpdated) return Ok("Updated Successfully");
            return NoContent();
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorBusiness.DeleteAuthor(id);
            if (result) return Ok("Deleted Successfully");
            return NoContent();
        }

    }
}