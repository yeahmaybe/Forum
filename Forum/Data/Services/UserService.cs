using System;
using Forum.Data.Models;
using Forum.Data.DTOs;
using Forum.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data.Services
{
	public class UserService
	{
		private ForumContext _context;
		public UserService(ForumContext context)
		{
			_context = context;
		}

		public async Task<User?> AddUser(UserDTO user)
		{
			User newUser = new User
			{
				Username = user.Username,
				Nickname = user.Nickname,
				Role = user.Role
			};
			
			var result = _context.Users.Add(newUser);
			await _context.SaveChangesAsync();
			return await Task.FromResult(result.Entity);
		}


		public async Task<User?> GetUser(int id)
		{
			var result = _context.Users.Include(a => a.Posts).Include(b => b.Comments).FirstOrDefault(user => user.Id == id);
			return await Task.FromResult(result);

		}

		public async Task<List<User>> GetUser()
		{
			var result = await _context.Users.Include(a => a.Posts).Include(b => b.Comments).ToListAsync();
			return await Task.FromResult(result);
		}

		public async Task<User?> UpdateUser(int id, User updatedUser)
		{
			var user = await _context.Users.Include(user => user.Posts).Include(b => b.Comments).FirstOrDefaultAsync(user => user.Id == id);
			if (user != null)
			{
				user.Username = updatedUser.Username;
				user.Nickname = updatedUser.Nickname;
				user.Role = updatedUser.Role;


				if (updatedUser.Posts.Any())
				{
					user.Posts = _context.Posts.ToList().IntersectBy(updatedUser.Posts, post => post).ToList();
				}
				if (updatedUser.Posts.Any())
				{
					user.Comments = _context.Comments.ToList().IntersectBy(updatedUser.Comments, comment => comment).ToList();
				}
				_context.Users.Update(user);
				_context.Entry(user).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return user;
			}

			return null;
		}


		public async Task<bool> DeleteUser(int id)
		{
			var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<List<IncompleteUserDTO>> GetUserIncomplete()
		{
			var users = await _context.Users.ToListAsync();
			List<IncompleteUserDTO> result = new List<IncompleteUserDTO>();
			users.ForEach(user => result.Add(new IncompleteUserDTO
			{
				Nickname = user.Nickname,
				Role = user.Role
			}));

			return await Task.FromResult(result);
		}

		public async Task<IncompleteUserDTO> GetUserIncomplete(int id)
		{
			var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
			IncompleteUserDTO result = new IncompleteUserDTO
			{
				Nickname = user.Nickname,
				Role = user.Role
			};

			return await Task.FromResult(result);
		}
	}
}
