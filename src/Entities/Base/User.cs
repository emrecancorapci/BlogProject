using System.ComponentModel.DataAnnotations;
using Entities.Relations;
using Entities.UniqueRelations;

namespace Entities.Base;

public class User : IEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public string Role { get; set; }

    // Profile
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? About { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? ProfileColorHex { get; set; }
    public bool? DarkMode { get; set; }
    public DateTime? BirthDate { get; set; }

    public bool? IsDeleted { get; set; }
    public bool? IsFrozen { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }

    public ICollection<Post> Posts { get; set; }
    public ICollection<Post> DeletedPosts { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Comment> DeletedComments { get; set; }
    public ICollection<Notification> Notifications { get; set; }

    public ICollection<PostViews> ViewedPosts { get; set; }
    public ICollection<PostEdits> EditedPosts { get; set; }
    public ICollection<CommentEdits> EditedComments { get; set; }

    public ICollection<UsersSavedPosts> SavedPosts { get; set; }
    public ICollection<UsersPostReactions> LikedPosts { get; set; }
    public ICollection<UsersCommentReactions> LikedComments { get; set; }
}