using BlogProject.Entities.Base;

namespace BlogProject.Entities.Relations;

public class UsersCommentReactions : IRelationEntity<User,Comment>
{
    public int CommentId { get; set; }
    public Comment Comment { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public int ReactionId { get; set; }
}