using System.ComponentModel.DataAnnotations.Schema;
using BlogProject.Entities.Base;

namespace BlogProject.Entities.Relations;

public class PostsEditors : IRelationEntity<Post,User>
{
    public string Summary { get; set; }
    public DateTime ModifiedDate { get; set; }
    
    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    [ForeignKey(nameof(EditorId))]
    public User Editor { get; set; }
    
    public int PostId { get; set; }
    public int EditorId { get; set; }
}