using System.ComponentModel.DataAnnotations.Schema;
using yabp.Entities.Base;

namespace yabp.Entities.UniqueRelations;

public class PostViews : IEntity
{
    public int Id { get; set; }

    public int PostId { get; set; }
    public int UserId { get; set; }

    public DateTime Viewed { get; set; }
    public int? ViewSeconds { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(PostId))]
    public User User { get; set; }
}