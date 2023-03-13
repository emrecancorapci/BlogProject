using System.ComponentModel.DataAnnotations;

namespace Business.Services.PostService.Dtos;

public class AddPostRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    [Required]
    [MinLength(32)]
    public string Content { get; set; }
    
    [Required]
    public int AuthorId { get; set; }
    public int CategoryId { get; set; } = 1;

    public string? ThumbnailUrl { get; set; }

    public bool AddCommentsEnabled { get; set; }
    public bool AddReactionsEnabled { get; set; }
}