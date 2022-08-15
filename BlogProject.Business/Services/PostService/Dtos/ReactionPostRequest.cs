namespace BlogProject.Business.Services.PostService.Dtos;

public class ReactionPostRequest
{
    public int userId { get; set; }
    public int postId { get; set; }
    public int reactionId { get; set; }
}