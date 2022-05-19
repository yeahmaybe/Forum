﻿using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Blazor.Data.Models;
using Blazor.Services;

namespace Blazor.Services;

public class UserProvider : IUserProvider
{
    private HttpClient _client;
    public UserProvider(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<User>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<User>>("/api/user");
    }

    public async Task<User> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<User>($"/api/user/{id}");
    }

    public async Task<bool> Add(User item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/user", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<User> Edit(User item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/user", httpContent);
        User user = JsonConvert.DeserializeObject<User>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(user);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/user/{id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}