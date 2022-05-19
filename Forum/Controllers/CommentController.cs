using Microsoft.AspNetCore.Mvc;
using Forum.Data.Services;
using Forum.Data.Models;
using Forum.Data.DTOs;

[Route("api/[controller]")]
[ApiController]

public class CommentController : ControllerBase
{
    private readonly CommentService _context;

    public CommentController(CommentService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
    {
        return await _context.GetComment();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
        var user = await _context.GetComment(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Comment>> PutComment(int id, [FromBody] Comment comment)
    {
        var result = await _context.UpdateComment(id, comment);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment([FromBody] CommentDTO comment)
    {
        var result = await _context.AddComment(comment);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _context.DeleteComment(id);
        if (comment)
        {
            return Ok();
        }
        return BadRequest();
    }

}