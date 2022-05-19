
using System.Collections;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Blazor.Data.Models;
using Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7267") });//{ BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IPostProvider, PostProvider>();
builder.Services.AddScoped<ICommentProvider, CommentProvider>();
builder.Services.AddScoped<IComparer<Post>, PostComparer>();
builder.Services.AddScoped<IComparer<Comment>, CommentComparer>();


await builder.Build().RunAsync();

