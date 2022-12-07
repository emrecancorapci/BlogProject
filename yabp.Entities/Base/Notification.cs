using System.Runtime.InteropServices.JavaScript;

namespace yabp.Entities.Base;

public class Notification : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string Description { get; set; }
    public string? Icon { get; set; }

    public bool? IsDeleted { get; set; }
    public bool? IsRead { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Read { get; set; }

    public User User { get; set; }
}