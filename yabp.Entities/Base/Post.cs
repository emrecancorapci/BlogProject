using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using yabp.Entities.Relations;
using yabp.Entities.UniqueRelations;

namespace yabp.Entities.Base;

public class Post : IEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    [Required]
    [MinLength(32)]
    public string Content { get; set; }

    public string? ThumbnailUrl { get; set; }
    public string? PostSummary { get; set; }

    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int? DeletedById { get; set; }

    public bool IsCommentsVisible { get; set; }
    public bool AddCommentsEnabled { get; set; }

    public bool IsReactionsVisible { get; set; }
    public bool AddReactionsEnabled { get; set; }

    public bool IsDeleted { get; set; }
    public bool IsApproved { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public User Author { get; set; }
    [ForeignKey(nameof(DeletedById))]
    public User? DeletedBy { get; set; }

    public ICollection<PostsTags>? Tags { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<PostEdits>? Editors { get; set; }
    public ICollection<PostViews>? ViewedUsers { get; set; }
    public ICollection<UsersSavedPosts>? UsersSaved { get; set; }
    public ICollection<UsersPostReactions>? Reactions { get; set; }
}