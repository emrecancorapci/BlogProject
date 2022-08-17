namespace BlogProject.Business.Services.CommentService.Dtos;

public class GetCommentResponse
{
    public string Content { get; set; }

    public int LikesCount { get; set; }

    public int PostId { get; set; }
    public int AuthorId { get; set; }
    public int? ParentId { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}