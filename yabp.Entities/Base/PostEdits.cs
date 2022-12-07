using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yabp.Entities.Base;

public class PostEdits : IRelationEntity<Post, User>
{
    [Key]
    public int Id { get; set; }
    public string? Summary { get; set; }
    public DateTime ModifiedDate { get; set; }

    public int PostId { get; set; }
    public int EditorId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(EditorId))]
    public User Editor { get; set; }
}