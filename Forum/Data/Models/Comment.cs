using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Data.Models
{
	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(Order = 1)]
		public int Id { set; get; }
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public Post Post { get; set; }
		public User User { get; set; }
		//public int PostId { get; set; }
		//public int UserId { get; set; }

		
	}
}

