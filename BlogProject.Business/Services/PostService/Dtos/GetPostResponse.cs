namespace BlogProject.Business.Services.PostService.Dtos;

public class GetPostResponse
{
    public string Title { get; set; }

    public string Content { get; set; }
    public string? ThumbnailUrl { get; set; }
    public int ViewCount { get; set; }

    public DateTime Created { get; set; }

    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
}
