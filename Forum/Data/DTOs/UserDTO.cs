using System;
using Forum.Data.Models;

namespace Forum.Data.DTOs
{
	public class UserDTO
	{
		public UserDTO()
		{
			
		}

		public string Username { get; set; }
		public string Nickname { get; set; }
		public string Role { get; set; }

		public int[] Posts { get; set; }
		public int[] Comments { get; set; }

	}
}

