using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using yabp.Entities.Base;

namespace yabp.Entities.UniqueRelations;

public class PostEdits : IEntity
{
    [Key]
    public int Id { get; set; }
    public string? Summary { get; set; }
    public DateTime Modified { get; set; }

    public int PostId { get; set; }
    public int EditorId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(EditorId))]
    public User Editor { get; set; }
}