using Entities.Base;

namespace Entities.Relations;

public class UsersSavedPosts : IRelationEntity<User,Post>
{
    public int PostId { get; set; }
    public int UserId { get; set; }

    public DateTime? SavedDate { get; set; }

    public Post Post { get; set; }
    public User User { get; set; }
}