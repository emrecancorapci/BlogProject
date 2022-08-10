namespace BlogProject.Business.Services.PostService.Dtos;

public class AddPostRequest
{

    public int Id { get; set; }

    public string Title { get; set; }
    public string Content { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? PostSummary { get; set; }

    public int CategoryId { get; set; }
    public int AuthorId { get; set; }

}