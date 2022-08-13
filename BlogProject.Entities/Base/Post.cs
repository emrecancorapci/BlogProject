using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogProject.Entities.Relations;

namespace BlogProject.Entities.Base;

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
    public string? PostSummary { get; set; }
    public string? ThumbnailUrl { get; set; }
    public int ViewCount { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public User Author { get; set; }
    [ForeignKey(nameof(DeletedById))]
    public User? DeletedBy { get; set; }

    public bool CommentsEnabled { get; set; }
    public bool ReactionsEnabled { get; set; }

    public bool IsDeleted { get; set; }
    public bool IsApproved { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }

    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int? DeletedById { get; set; }

    public ICollection<Comment>? Comments { get; set; }
    public ICollection<PostsEditors>? Editors { get; set; }
    public ICollection<PostsTags>? Tags { get; set; }
    public ICollection<UsersPostReactions>? Reactions { get; set; }
}