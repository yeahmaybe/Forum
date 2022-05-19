using Blazor.Data.DTOs;
using Blazor.Data.Models;

namespace Blazor.Services;

public interface ICommentProvider
{
    Task<List<Comment>> GetAll();
    Task<List<Comment>> GetForPost(int postId);
    Task<Comment> GetOne(int id);
    Task<bool> Add(CommentDTO item);
    Task<Comment> Edit(Comment item);
    Task<bool> Remove(int id);
}