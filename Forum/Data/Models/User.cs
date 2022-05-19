using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Data.Models;

public class User
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Nickname { get; set; }
    public string Role { get; set; }

    public IEnumerable<Post> Posts { get; set; }
    public IEnumerable<Comment> Comments { get; set; }

}