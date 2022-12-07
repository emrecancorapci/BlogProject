using System.ComponentModel.DataAnnotations;

namespace yabp.Business.Services.PostService.Dtos;

public class AddPostRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    [Required]
    [MinLength(32)]
    public string Content { get; set; }
    
    public string? ThumbnailUrl { get; set; }
    public string? PostSummary { get; set; }

    [Required]
    public bool CommentsEnabled { get; set; }
    [Required]
    public bool ReactionsEnabled { get; set; }

    public int? CategoryId { get; set; }
    [Required]
    public int AuthorId { get; set; }
}