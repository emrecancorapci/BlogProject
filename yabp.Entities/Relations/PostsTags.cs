using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using yabp.Entities.Base;

namespace yabp.Entities.Relations;

public class PostsTags : IRelationEntity<Post,Tag>
{
    public int PostId { get; set; }
    public int TagId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }
}