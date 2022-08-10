using BlogProject.Entities.Base;

namespace BlogProject.Entities.Relations;

public class UsersLikes : IRelationEntity<User,Post>
{
    public int PostId { get; set; }
    public Post Post { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
}