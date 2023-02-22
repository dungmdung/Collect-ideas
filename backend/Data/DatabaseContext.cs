using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Idea> Ideas { get; set; }

        public DbSet<IdeaDetail> IdeaDetails { get; set; }

        public DbSet<Thumb> Thumbs { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(c => c.ToTable("Category"));

            builder.Entity<Idea>(i => i.ToTable("Idea"));

            builder.Entity<Comment>(c => c.ToTable("Comment"));

            builder.Entity<Thumb>(t => t.ToTable("Thumb"));

            builder.Entity<User>(u => u.ToTable("User"));

            builder.Entity<IdeaDetail>(i => i.ToTable("IdeaDetail"));

            builder.Entity<IdeaDetail>().HasKey(d => new { d.IdeaId, d.CategoryId });

            builder.Entity<IdeaDetail>()
                .HasOne(d => d.Categories)
                .WithMany(d => d.IdeaDetails)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<IdeaDetail>()
                .HasOne(d => d.Ideas)
                .WithMany(d => d.IdeaDetails)
                .HasForeignKey(d => d.IdeaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Thumb>()
                .HasOne(t => t.Ideas)
                .WithMany(t => t.Thumbs)
                .HasForeignKey(t => t.IdeaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Thumb>()
                .HasOne(t => t.Users)
                .WithMany(t => t.Thumbs)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Idea>()
                .HasOne(i => i.Users)
                .WithMany(i => i.Ideas)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Comment>()
                .HasOne(c => c.Ideas)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.IdeaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Comment>()
                .HasOne(c => c.Users)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}