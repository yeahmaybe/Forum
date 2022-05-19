using System;
namespace Blazor.Data.DTOs
{
	public class CommentDTO
	{
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public int Post { get; set; }
		public int User { get; set; }

		
	}
}

