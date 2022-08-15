using System.ComponentModel.DataAnnotations;

namespace BlogProject.Business.Services.PostService.Dtos;

public class UpdatePostContentRequest
{
    [Required]
    public int PostId { get; set; }
    
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    [Required]
    [MinLength(100)]
    public string Content { get; set; }
    
    public string? PostSummary { get; set; }

    [Required]
    public int EditorId { get; set; }
    public string? EditionSummary { get; set; }
}