using BlogProject.Entities.Base;

namespace BlogProject.Entities.Relations;

public class PostsTags : IRelationEntity<Post,Tag>
{
    public int PostId { get; set; }
    public Post Post { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}