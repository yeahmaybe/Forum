using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Data.Models
{
	public class Post
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(Order = 1)]
		public int Id { set; get; }
		public string Label { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public User User { get; set; }

		public IEnumerable<Comment> Comments { get; set; }


	}
}

