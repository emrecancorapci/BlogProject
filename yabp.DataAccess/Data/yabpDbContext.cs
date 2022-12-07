using yabp.Entities.Base;
using yabp.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using yabp.Entities.UniqueRelations;

namespace yabp.DataAccess.Data;

public class yabpDbContext : DbContext
{
    public yabpDbContext(DbContextOptions<yabpDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    public DbSet<PostsTags> PostsTags { get; set; }
    public DbSet<UsersPostReactions> UsersPostReactions { get; set; }
    public DbSet<UsersCommentReactions> UsersCommentReactions { get; set; }
    public DbSet<UsersSavedPosts> UsersSavedPosts { get; set; }

    public DbSet<PostViews> PostViews { get; set; }
    public DbSet<PostEdits> PostEdits { get; set; }
    public DbSet<CommentEdits> CommentEdits { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("blog");
        
        // UNIQUE TABLES //

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
        builder.Entity<Comment>().Property(c => c.Id).IsRequired();
        builder.Entity<Comment>().Property(c => c.Content).IsRequired();

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

        // Notification
        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.UserId).IsRequired();
        builder.Entity<Notification>().Property(n => n.Description).IsRequired();

        builder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId);


        // Tag
        builder.Entity<Tag>().HasKey(t => t.Id);
        builder.Entity<Tag>().Property(u => u.Id).IsRequired();
        builder.Entity<Tag>().Property(u => u.Name).IsRequired();

        // Category
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(u => u.Id).IsRequired();
        builder.Entity<Category>().Property(u => u.Name).IsRequired();


        // RELATIONAL TABLES //

        // PostsTags
        builder.Entity<PostsTags>().HasKey(pt => new { pt.PostId, pt.TagId });
        builder.Entity<PostsTags>()
            .HasOne(pt => pt.Post)
            .WithMany(p => p.Tags)
            .HasForeignKey(pt => pt.PostId);
        builder.Entity<PostsTags>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.Posts)
            .HasForeignKey(pt => pt.TagId);


        // UsersPostReactions
        builder.Entity<UsersPostReactions>().HasKey(ul => new { ul.UserId, ul.PostId });
        builder.Entity<UsersPostReactions>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.LikedPosts)
            .HasForeignKey(ul => ul.UserId);
        builder.Entity<UsersPostReactions>()
            .HasOne(ul => ul.Post)
            .WithMany(p => p.Reactions)
            .HasForeignKey(ul => ul.PostId);

        // UsersCommentReactions
        builder.Entity<UsersCommentReactions>().HasKey(ul => new { ul.UserId, ul.CommentId });
        builder.Entity<UsersCommentReactions>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.LikedComments)
            .HasForeignKey(ul => ul.UserId);
        builder.Entity<UsersCommentReactions>()
            .HasOne(ul => ul.Comment)
            .WithMany(p => p.Reactions)
            .HasForeignKey(ul => ul.CommentId);

        // UsersSavedPosts
        builder.Entity<UsersSavedPosts>().HasKey(ul => new { ul.UserId, ul.PostId });
        builder.Entity<UsersSavedPosts>()
            .HasOne(ul => ul.User)
            .WithMany(u => u.SavedPosts)
            .HasForeignKey(ul => ul.UserId);
        builder.Entity<UsersSavedPosts>()
            .HasOne(up => up.Post)
            .WithMany(p => p.UsersSaved)
            .HasForeignKey(ul => ul.PostId);
        
        // UNIQUE RELATIONS //

        // PostEdits
        builder.Entity<PostEdits>().HasKey(pe => pe.Id);
        builder.Entity<PostEdits>().Property(pe => pe.Modified).IsRequired();
        builder.Entity<PostEdits>()
            .HasOne(pe => pe.Post)
            .WithMany(p => p.Editors)
            .HasForeignKey(pe => pe.PostId);
        builder.Entity<PostEdits>()
            .HasOne(pe => pe.Editor)
            .WithMany(u => u.EditedPosts)
            .HasForeignKey(pe => pe.EditorId);

        // PostViews
        builder.Entity<PostViews>().HasKey(pe => pe.Id);
        builder.Entity<PostViews>().Property(pe => pe.Viewed).IsRequired();
        builder.Entity<PostViews>()
            .HasOne(pe => pe.Post)
            .WithMany(p => p.ViewedUsers)
            .HasForeignKey(pe => pe.PostId);
        builder.Entity<PostViews>()
            .HasOne(pe => pe.User)
            .WithMany(u => u.ViewedPosts)
            .HasForeignKey(pe => pe.UserId);

        // CommentEdits
        builder.Entity<CommentEdits>().HasKey(ce => ce.Id);
        builder.Entity<CommentEdits>().Property(ce => ce.Modified).IsRequired();
        builder.Entity<CommentEdits>()
            .HasOne(ce => ce.Comment)
            .WithMany(p => p.Editors)
            .HasForeignKey(ce => ce.CommentId);
        builder.Entity<CommentEdits>()
            .HasOne(ce => ce.Editor)
            .WithMany(u => u.EditedComments)
            .HasForeignKey(ce => ce.EditorId);
    }
}