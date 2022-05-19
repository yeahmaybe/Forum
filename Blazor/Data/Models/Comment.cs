using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Data.Models
{
	public class Comment
	{
		public int Id { set; get; }
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public Post Post { get; set; }
		public User User { get; set; }

	}
}

