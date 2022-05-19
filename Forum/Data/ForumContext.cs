using System;
using Microsoft.EntityFrameworkCore;
using Forum.Data.Models;

namespace Forum.Data
{
	public class ForumContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }

		public ForumContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(
				@"Host=localhost;
				Database=forum;
				Username=postgres;
				Password=postgres")
				.UseSnakeCaseNamingConvention()
				.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<Post>().Property(p => p.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<Comment>().Property(p => p.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<User>().HasMany(au => au.Posts);
			modelBuilder.Entity<User>().HasMany(au => au.Comments);
			modelBuilder.Entity<Post>().HasMany(ar => ar.Comments);

		}


	}
}

