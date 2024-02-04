using StudentHive.Domain.Entities;

namespace StudentHive.Domain.Dtos;

public class UserUpdateDTO /* It's just for transferring data */
{ 
    public int ID_User { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string ProfilePhotoUrl { get; set; } = null!;
}