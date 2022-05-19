using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Nickname { get; set; }
    public string Role { get; set; }

    public IEnumerable<Post> Posts { get; set; }
    public IEnumerable<Comment> Comments { get; set; }

}