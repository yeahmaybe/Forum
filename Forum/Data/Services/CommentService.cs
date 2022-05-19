using System;
using Forum.Data;
using Forum.Data.Models;
using Forum.Data.DTOs;

using Microsoft.EntityFrameworkCore;


namespace Forum.Data.Services
{
	public class CommentService
	{
		private ForumContext _context;
		public CommentService(ForumContext context)
		{
			_context = context;
		}


		public async Task<Comment?> AddComment(CommentDTO comment)
		{
			Comment newComment = new Comment
			{
				Content = comment.Content,
				Date = comment.Date
			};

			newComment.User = _context.Users.FirstOrDefault(user => user.Id == comment.User);
			newComment.Post = _context.Posts.FirstOrDefault(post => post.Id == comment.Post);

			var result = _context.Comments.Add(newComment);
			await _context.SaveChangesAsync();
			return await Task.FromResult(result.Entity);
		}


		public async Task<Comment?> GetComment(int id)
		{
			var result = _context.Comments.Include(b => b.Post).Include(a => a.User).FirstOrDefault(comment => comment.Id == id);
			return await Task.FromResult(result);

		}

		public async Task<List<Comment>> GetComment()
		{
			var result = await _context.Comments.Include(b => b.Post).Include(a => a.User).ToListAsync();
			return await Task.FromResult(result);
		}

		public async Task<Comment?> UpdateComment(int id, Comment updatedComment)
		{
			var comment = await _context.Comments.Include(a => a.User).Include(b => b.Post).FirstOrDefaultAsync(comment => comment.Id == id);
			if (comment != null)
			{
				comment.Content = updatedComment.Content;
				comment.Date = updatedComment.Date;
				comment.User = updatedComment.User;
				comment.Post = updatedComment.Post;

				_context.Comments.Update(comment);
				_context.Entry(comment).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return comment;
			}

			return null;
		}


		public async Task<bool> DeleteComment(int id)
		{
			var comment = await _context.Comments.Include(a => a.User).Include(b => b.Post).FirstOrDefaultAsync(comment => comment.Id == id);
			if (comment != null)
			{
				_context.Comments.Remove(comment);
				await _context.SaveChangesAsync();
				return true;
			}

			return false;
		}
	}
}

