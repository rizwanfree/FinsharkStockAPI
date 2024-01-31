using Finshark.Interfaces;
using Finshark.Mappers;
using Finshark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommectRepository _comment;

        public CommentController(ICommectRepository comment)
        {
            _comment = comment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _comment.GetAllAsync();

            var commentDTO = comments.Select(s => s.ToCommentDTO());
            return Ok(commentDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _comment.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDTO());
        }
    }
}
