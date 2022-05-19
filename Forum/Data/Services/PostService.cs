using System;
using Forum.Data.Models;
using Forum.Data;
using Forum.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data.Services
{
	public class PostService
	{
		private ForumContext _context;
		public PostService(ForumContext context)
		{
			_context = context;
		}

		public async Task<Post?> AddPost(PostDTO post)
		{
			Post newPost = new Post
			{
				Label = post.Label,
				Content = post.Content,
				Date = post.Date,
			};

			newPost.User = _context.Users.FirstOrDefault(user => user.Id == post.User);
			newPost.Comments = new List<Comment>(0);

			var result = _context.Posts.Add(newPost);
			await _context.SaveChangesAsync();
			return await Task.FromResult(result.Entity);
		}


		public async Task<Post?> GetPost(int id)
		{
			var result = _context.Posts.Include(a => a.User).Include(b => b.Comments).FirstOrDefault(post => post.Id == id);
			return await Task.FromResult(result);

		}

		public async Task<List<Post>> GetPost()
		{
			var result = await _context.Posts.Include(b => b.Comments).Include(a => a.User).ToListAsync();
			return await Task.FromResult(result);
		}

		public async Task<Post?> UpdatePost(int id, PostDTO updatedPost)
		{
			var post = await _context.Posts.Include(b => b.Comments).Include(a => a.User).FirstOrDefaultAsync(post => post.Id == id);
			if (post != null)
			{
				post.Label = updatedPost.Label;
				post.Content = updatedPost.Content;
				
				_context.Posts.Update(post);
				_context.Entry(post).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return post;
			}

			return null;
		}


		public async Task<bool> DeletePost(int id)
		{
			var post = await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);
			if (post != null)
			{
				_context.Posts.Remove(post);
				await _context.SaveChangesAsync();
				return true;
			}

			return false;
		}

		public async Task<List<IncompletePostDTO>> GetPostIncomplete()
		{
			var posts = await _context.Posts.Include(b => b.Comments).Include(a => a.User).ToListAsync();
			
			List<IncompletePostDTO> result = new List<IncompletePostDTO>();
			posts.ForEach(post => result.Add(new IncompletePostDTO
			{
				Label = post.Label,
				Date = post.Date,
				User = post.User.Id
			}));

			return await Task.FromResult(result);

		}

		public async Task<IncompletePostDTO> GetPostIncomplete(int id)
		{
			var post = await _context.Posts.Include(b => b.Comments).Include(a => a.User).FirstOrDefaultAsync(post => post.Id == id);
			IncompletePostDTO result = new IncompletePostDTO
			{
				Label = post.Label,
				Date = post.Date,
				User = post.User.Id
			};

			return await Task.FromResult(result);
		}

	}
}

