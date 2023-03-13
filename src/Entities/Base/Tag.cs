using System.ComponentModel.DataAnnotations;
using Entities.Relations;

namespace Entities.Base;

public class Tag : IEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ? Description { get; set; }

    public bool ? IsVisible { get; set; }
    public bool ? IsDeleted { get; set; }

    public ICollection<PostsTags> Posts { get; set; }
}