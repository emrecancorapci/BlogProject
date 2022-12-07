using yabp.Entities.Base;
using yabp.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace yabp.DataAccess.Data;

public class yabpDbContext : DbContext
{
    public yabpDbContext(DbContextOptions<yabpDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<PostsTags> PostsTags { get; set; }
    public DbSet<PostEdits> PostsEditors { get; set; }
    public DbSet<UsersPostReactions> UsersPostReactions { get; set; }
    public DbSet<UsersCommentReactions> UsersCommentReactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Blog");
        
        // User
        builder.Entity<User>().HasKey(u => u.Id);
        
        builder.Entity<User>().Property(u => u.Id).IsRequired();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.Password).IsRequired();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.Role).IsRequired();

        // Post
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().Property(u => u.Id).IsRequired();
        builder.Entity<Post>().Property(u => u.Title).IsRequired();
        builder.Entity<Post>().Property(u => u.Content).IsRequired();

        builder.Entity<Post>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CategoryId);
        builder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.AuthorId);
        builder.Entity<Post>()
            .HasOne(p => p.DeletedBy)
            .WithMany(u => u.DeletedPosts)
            .HasForeignKey(p => p.DeletedById);

        // Comment 
        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(u => u.Id).IsRequired();
        builder.Entity<Comment>().Property(u => u.Content).IsRequired();

        builder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId);
        builder.Entity<Comment>()
            .HasOne(c => c.DeletedBy)
            .WithMany(u => u.DeletedComments)
            .HasForeignKey(c => c.DeletedById);
        builder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId);
        builder.Entity<Comment>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId);

        // PostEdits
        builder.Entity<PostEdits>().HasKey(pe => pe.Id);
        builder.Entity<PostEdits>().Property(pe => pe.ModifiedDate).IsRequired();
        builder.Entity<PostEdits>()
            .HasOne(pe => pe.Post)
            .WithMany(p => p.Editors)
            .HasForeignKey(pe => pe.PostId);
        builder.Entity<PostEdits>()
            .HasOne(pe => pe.Editor)
            .WithMany(u => u.EditedPosts)
            .HasForeignKey(pe => pe.EditorId);

        // PostEdits
        builder.Entity<CommentEdits>().HasKey(ce => ce.Id);
        builder.Entity<CommentEdits>().Property(ce => ce.ModifiedDate).IsRequired();
        builder.Entity<CommentEdits>()
            .HasOne(ce => ce.Comment)
            .WithMany(p => p.Editors)
            .HasForeignKey(ce => ce.CommentId);
        builder.Entity<CommentEdits>()
            .HasOne(ce => ce.Editor)
            .WithMany(u => u.EditedComments)
            .HasForeignKey(ce => ce.EditorId);

        // Tag
        builder.Entity<Tag>().HasKey(t => t.Id);
        builder.Entity<Tag>().Property(u => u.Id).IsRequired();
        builder.Entity<Tag>().Property(u => u.Name).IsRequired();

        // Category
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(u => u.Id).IsRequired();
        builder.Entity<Category>().Property(u => u.Name).IsRequired();

        // Relations
        builder.Entity<PostsTags>().HasKey(pt => new { pt.PostId, pt.TagId });
        builder.Entity<PostsTags>()
            .HasOne(pt => pt.Post)
            .WithMany(p => p.Tags)
            .HasForeignKey(pt => pt.PostId);
        builder.Entity<PostsTags>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.Posts)
            .HasForeignKey(pt => pt.TagId);


        builder.Entity<UsersPostReactions>().HasKey(ul => new { ul.UserId, ul.PostId });
        builder.Entity<UsersPostReactions>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.LikedPosts)
            .HasForeignKey(ul => ul.UserId);
        builder.Entity<UsersPostReactions>()
            .HasOne(ul => ul.Post)
            .WithMany(p => p.Reactions)
            .HasForeignKey(ul => ul.PostId);

        builder.Entity<UsersCommentReactions>().HasKey(ul => new { ul.UserId, ul.CommentId });
        builder.Entity<UsersCommentReactions>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.LikedComments)
            .HasForeignKey(ul => ul.UserId);
        builder.Entity<UsersCommentReactions>()
            .HasOne(ul => ul.Comment)
            .WithMany(p => p.Reactions)
            .HasForeignKey(ul => ul.CommentId);
    }
}