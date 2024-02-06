using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class UserUpdateDTO /* It's just for transferring data */
{ 
    // public int IdUser { get; set; }
    public int UserAge { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!; 
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public long PhoneNumber { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public string? GenderU { get; set; }

}