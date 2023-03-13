using Entities.Base;

namespace Entities.Relations;

public class UsersPostReactions : IRelationEntity<User,Post>
{
    public int PostId { get; set; }
    public int UserId { get; set; }

    public int ReactionId { get; set; }

    public Post Post { get; set; }
    public User User { get; set; }
}