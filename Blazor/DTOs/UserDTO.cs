using System;
using Blazor.Data.Models;

namespace Blazor.Data.DTOs
{
	public class UserDTO
	{

		public string Username { get; set; }
		public string Nickname { get; set; }
		public string Role { get; set; }

		public int[] Posts { get; set; }
		public int[] Comments { get; set; }

	}
}

