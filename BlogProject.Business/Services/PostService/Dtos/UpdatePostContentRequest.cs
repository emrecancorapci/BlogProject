namespace BlogProject.Business.Services.PostService.Dtos;

public class UpdatePostContentRequest
{
    public int PostId { get; set; }
    
    public string Title { get; set; }
    public string Content { get; set; }
    
    public string? ThumbnailUrl { get; set; }
    public string? PostSummary { get; set; }

    public bool CommentsEnabled { get; set; }
    public bool ReactionsEnabled { get; set; }

    public int CategoryId { get; set; }
    
    public int EditorId { get; set; }
    public string? EditionSummary { get; set; }
}