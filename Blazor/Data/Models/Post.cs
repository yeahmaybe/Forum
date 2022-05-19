using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Data.Models
{
	public class Post
	{
		public int Id { set; get; }
		public string Label { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public User User { get; set; }

		public IEnumerable<Comment> Comments { get; set; }


	}
}

