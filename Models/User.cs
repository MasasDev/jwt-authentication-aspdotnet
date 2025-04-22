namespace JWT_AUTHENTICATION.Models;

public class User
{
    public string Name {get; set;} = null!;
    public string PasswordHash {get; set;} = null!;
}