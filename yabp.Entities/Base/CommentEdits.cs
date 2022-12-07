using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yabp.Entities.Base;

public class CommentEdits : IRelationEntity<Post, User>
{
    [Key]
    public int Id { get; set; }
    public string? Summary { get; set; }
    public DateTime ModifiedDate { get; set; }

    public int CommentId { get; set; }
    public int EditorId { get; set; }

    [ForeignKey(nameof(CommentId))]
    public Comment Comment { get; set; }
    [ForeignKey(nameof(EditorId))]
    public User Editor { get; set; }
}