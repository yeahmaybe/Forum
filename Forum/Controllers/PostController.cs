using Microsoft.AspNetCore.Mvc;
using Forum.Data.Services;
using Forum.Data.Models;
using Forum.Data.DTOs;

[Route("api/[controller]")]
[ApiController]


public class PostController : ControllerBase
{
    private readonly PostService _context;

    public PostController(PostService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPost()
    {
        return await _context.GetPost();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.GetPost(id);

        if (post == null)
        {
            return NotFound();
        }

        return post;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> PutPost(int id, [FromBody] PostDTO post)
    {
        var result = await _context.UpdatePost(id, post);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> PostPost([FromBody] PostDTO post)
    {
        var result = await _context.AddPost(post);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.DeletePost(id);
        if (post)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("incomplete")]
    public async Task<ActionResult<IEnumerable<IncompletePostDTO>>> GetPostIncomplete()
    {
        return await _context.GetPostIncomplete();
    }

    [HttpGet("incomplete/{id}")]
    public async Task<ActionResult<IncompletePostDTO>> GetPostIncomplete(int id)
    {
        return await _context.GetPostIncomplete(id);
    }
}

