using System.Net.Http.Json;
using Blazor.Data.DTOs;
using Blazor.Data.Models;
using Newtonsoft.Json;

namespace Blazor.Services;

public class CommentProvider : ICommentProvider
{
    private HttpClient _client;
    public CommentProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Comment>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Comment>>("/api/comment");
    }

    public async Task<List<Comment>> GetForPost(int postId)
    {
        var comments = await _client.GetFromJsonAsync<List<Comment>>("/api/comment");
        return comments.FindAll(comm => comm.Post.Id == postId);
    }
    public async Task<Comment> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Comment>($"/api/comment/{id}");
    }
    

    public async Task<bool> Add(CommentDTO item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/comment", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Comment> Edit(Comment item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/comment/{item.Id}", httpContent);
        Comment comment = JsonConvert.DeserializeObject<Comment>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(comment);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/comment/{id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}