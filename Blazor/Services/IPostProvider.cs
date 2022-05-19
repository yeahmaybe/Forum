using Blazor.Data.DTOs;
using Blazor.Data.Models;

namespace Blazor.Services;

public interface IPostProvider
{
    Task<List<Post>> GetAll();
    Task<Post> GetOne(int id);
    Task<bool> Add(PostDTO item);
    Task<Post> Edit(int id, PostDTO item);
    Task<bool> Remove(int id);
}