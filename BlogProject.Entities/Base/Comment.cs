using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogProject.Entities.Relations;

namespace BlogProject.Entities.Base;

public class Comment : IEntity
{
    [Key]
    public int Id { get; set; }
    public string Content { get; set; }

    public int PostId { get; set; }
    public int AuthorId { get; set; }
    public int? DeletedById { get; set; }
    public int? ParentId { get; set; }

    public bool IsDeleted { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(AuthorId))]
    public User Author { get; set; }
    [ForeignKey(nameof(DeletedById))]
    public User? DeletedBy { get; set; }
    [ForeignKey(nameof(ParentId))]
    public Comment? Parent { get; set; }

    public ICollection<Comment>? Children { get; set; }
    public ICollection<UsersCommentReactions>? Reactions { get; set; }
}