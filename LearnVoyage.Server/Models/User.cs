using System;

namespace LearnVoyage.Server.Models;

public class User
{
    public int Id { get; private set; }

    public string? Name { get; private set; }

    public string? Mail { get; private set; }
    
    public string? Password { get; private set; }
}