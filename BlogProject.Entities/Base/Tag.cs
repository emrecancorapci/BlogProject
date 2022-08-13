using System.ComponentModel.DataAnnotations;
using BlogProject.Entities.Relations;

namespace BlogProject.Entities.Base;

public class Tag : IEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public ICollection<PostsTags> Posts { get; set; }
}