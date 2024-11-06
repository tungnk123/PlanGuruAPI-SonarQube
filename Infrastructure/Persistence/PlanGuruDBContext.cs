using Domain.Entities;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PlanGuruDBContext : DbContext
    {
        public PlanGuruDBContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostUpvote> PostUpvotes { get; set; }
        public DbSet<PostDevote> PostDevotes { get; set; }
        public DbSet<PostShare> PostShares { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentUpvote> CommentUpvotes { get; set; }
        public DbSet<CommentDevote> CommentDevotes { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatImageAndVideo> ChatImageAndVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new ChatRoomConfiguration());
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());     
            modelBuilder.ApplyConfiguration(new PostUpvoteConfiguration());
            modelBuilder.ApplyConfiguration(new PostDevoteConfiguration());
            modelBuilder.ApplyConfiguration(new CommentUpvoteConfiguration());
            modelBuilder.ApplyConfiguration(new CommentDevoteConfiguration());
            modelBuilder.ApplyConfiguration(new PostShareConfiguration());
            modelBuilder.ApplyConfiguration(new ChatImagesAndVideosConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
