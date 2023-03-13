namespace Business.Services.CommentService.Dtos;

public class AddCommentRequest
{
    public string Content { get; set; }

    public int PostId { get; set; }
    public int AuthorId { get; set; }
    public int? ParentId { get; set; }
}