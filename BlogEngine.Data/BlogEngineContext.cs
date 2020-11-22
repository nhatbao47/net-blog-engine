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
            ConfigModelBuilderForUsers(modelBuilder);
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
        }

        void ConfigModelBuilderForPost(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Post>();
            builder.ToTable("Post");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CategoryId)
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

        void ConfigModelBuilderForUsers(ModelBuilder modelBuilder)
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
    }
}
