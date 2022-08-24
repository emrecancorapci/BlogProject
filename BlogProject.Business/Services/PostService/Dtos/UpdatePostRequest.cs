using System.ComponentModel.DataAnnotations;

namespace BlogProject.Business.Services.PostService.Dtos;

public class UpdatePostRequest
{
    [Required]
    public int PostId { get; set; }
    
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    [Required]
    [MinLength(32)]
    public string Content { get; set; }
    
    public string? ThumbnailUrl { get; set; }
    public string? PostSummary { get; set; }

    public int AuthorId { get; set; }
    public int CategoryId { get; set; }

    public bool CommentsEnabled { get; set; }
    public bool ReactionsEnabled { get; set; }

    public bool IsDeleted { get; set; }
    public bool? IsApproved { get; set; }
}