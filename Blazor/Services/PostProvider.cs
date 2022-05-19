using System.Net.Http.Json;
using Blazor.Data.DTOs;
using Blazor.Data.Models;
using Newtonsoft.Json;

namespace Blazor.Services;

public class PostProvider : IPostProvider
{
    private HttpClient _client;
    public PostProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Post>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Post>>("/api/post");
    }

    public async Task<Post> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Post>($"/api/post/{id}");
    }

    public async Task<bool> Add(PostDTO item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync("/api/post", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Post> Edit(int id,PostDTO item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/post/{id}", httpContent);
        Post post = JsonConvert.DeserializeObject<Post>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(post);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/post/{id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}