namespace BlogProject.Business.Services.PostService.Dtos;

public class UpdatePostContentRequest
{
    public int PostId { get; set; }
    public int EditorId { get; set; }
    public string? PostSummary { get; set; }
    public string Content { get; set; }
    public string EditionSummary { get; set; }
}