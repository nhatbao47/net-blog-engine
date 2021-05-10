using BlogEngine.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogEngine.Data
{
    public class BlogEngineContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogEngineContext(DbContextOptions<BlogEngineContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
            ConfigureModelBuilderForCategory(modelBuilder);
            ConfigModelBuilderForPost(modelBuilder);
            ConfigModelBuilderForUser(modelBuilder);
            ConfigModelBuilderForComment(modelBuilder);
            ConfigModelBuilderForTag(modelBuilder);
            ConfigModelBuilderForPostTag(modelBuilder);
        }

        void ConfigureModelBuilderForCategory(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Category>();
            builder.ToTable("Category");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Slug)
                .HasMaxLength(255);
        }

        void ConfigModelBuilderForPost(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Post>();
            builder.ToTable("Post");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Slug)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.Content)
                .IsRequired();

            builder.Property(p => p.ThumbnailImage)
                .HasMaxLength(255);

            builder.Property(p => p.CreatedDate)
                .IsRequired();
        }

        void ConfigModelBuilderForUser(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<User>();
            builder.ToTable("User");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Username)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(60)
                .IsRequired();
        }

        void ConfigModelBuilderForComment(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Comment>();
            builder.ToTable("Comment");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.EmailAddress)
                .HasMaxLength(254);

            builder.Property(p => p.Content)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(p => p.CommentDate)
                .IsRequired();

            builder.Property(p => p.PostId)
                .IsRequired();
        }

        void ConfigModelBuilderForTag(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Tag>();
            builder.ToTable("Tag");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Slug)
                .HasMaxLength(255);
        }

        void ConfigModelBuilderForPostTag(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<PostTag>();
            builder.ToTable("PostTag");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PostId).IsRequired();
            builder.Property(p => p.TagId).IsRequired();
        }
    }
}
