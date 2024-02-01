namespace StudentHive.Domain.Dtos;

public class UserDTO
{
    public int ID_User { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
}