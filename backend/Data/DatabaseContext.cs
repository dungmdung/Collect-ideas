using Common.Enums;
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

        public DbSet<Thumb> Thumbs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(c => c.ToTable("Category"));

            builder.Entity<Idea>(i => i.ToTable("Idea"));

            builder.Entity<Comment>(c => c.ToTable("Comment"));

            builder.Entity<Thumb>(t => t.ToTable("Thumb"));

            builder.Entity<User>(u => u.ToTable("User"));

            builder.Entity<Event>(f => f.ToTable("Event"));

            builder.Entity<Notification>(n => n.ToTable("Notification"));

            builder.Entity<Thumb>()
                .HasOne(t => t.Idea)
                .WithMany(t => t.Thumbs)
                .HasForeignKey(t => t.IdeaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Thumb>()
                .HasOne(t => t.User)
                .WithMany(t => t.Thumbs)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Idea>()
                .HasOne(i => i.User)
                .WithMany(i => i.Ideas)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Idea>()
                .HasOne(i => i.Event)
                .WithMany(i => i.Ideas)
                .HasForeignKey(i => i.EventId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Idea>()
                .HasMany(i => i.Categories)
                .WithMany(c => c.Ideas)
                .UsingEntity(i => i.ToTable("IdeaCategories"));

            builder.Entity<Comment>()
                .HasOne(c => c.Idea)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.IdeaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Notification>()
                .HasOne(n => n.Idea)
                .WithMany(n => n.Notifications)
                .HasForeignKey(n => n.IdeaId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany(e => e.Events)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Staff", Password = "123456", FullName = "Staff", Email = "tonydo0307@gmail.com", PhoneNumber = 11112222, Faculty = "IT", Role = UserRoleEnum.Staff},
                new User { Id = 2, UserName = "Admin", Password = "123456", FullName = "Admin", Email = "tonydo0307@gmail.com", PhoneNumber = 11112222, Faculty = "IT", Role = UserRoleEnum.Admin },
                new User { Id = 3, UserName = "QAManager", Password = "123456", FullName = "QAManager", Email = "tonydo0307@gmail.com", PhoneNumber = 11112222, Faculty = "IT", Role = UserRoleEnum.QAManager },
                new User { Id = 4, UserName = "QACoordinator", Password = "123456", FullName = "QACoordinator", Email = "tonydo0307@gmail.com", PhoneNumber = 11112222, Faculty = "IT", Role = UserRoleEnum.QACoordinator}
                );
        }
    }
}