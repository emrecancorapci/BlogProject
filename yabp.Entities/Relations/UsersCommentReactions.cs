using yabp.Entities.Base;

namespace yabp.Entities.Relations;

public class UsersCommentReactions : IRelationEntity<User,Comment>
{
    public int CommentId { get; set; }
    public int UserId { get; set; }

    public int ReactionId { get; set; }
    public DateTime ReactionDate { get; set; }

    public User User { get; set; }
    public Comment Comment { get; set; }
    
}