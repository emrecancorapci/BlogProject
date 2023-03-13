using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Entities.Base;

namespace Entities.Relations;

public class PostsTags : IRelationEntity<Post,Tag>
{
    public int PostId { get; set; }
    public int TagId { get; set; }

    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }
}