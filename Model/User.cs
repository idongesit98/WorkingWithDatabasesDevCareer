using System;

namespace WorkingWithDatabasesDevCareer.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public bool HasBook { get; set; } = false;

}
