using System;
namespace Blazor.Data.DTOs
{
	public class PostDTO
	{
		public string Label { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }

		public int User { get; set; }
		public int[] Comments { get; set; }
	}
}

