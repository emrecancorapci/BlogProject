﻿namespace BlogProject.Entities.Base;

public class Category : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Post> Posts { get; set; }
}