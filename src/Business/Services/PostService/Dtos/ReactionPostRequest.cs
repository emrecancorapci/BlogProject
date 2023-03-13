namespace Business.Services.PostService.Dtos;

public class ReactionPostRequest
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public int ReactionId { get; set; }
}