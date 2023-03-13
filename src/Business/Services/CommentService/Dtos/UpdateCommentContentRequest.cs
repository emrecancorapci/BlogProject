namespace Business.Services.CommentService.Dtos;

public class UpdateCommentContentRequest
{
    public int PostId { get; set; }
    public int EditorId { get; set; }
}