namespace StudentHive.Domain.Entities;
public class User{
    public required int ID_User { get; set; }
    public required int User_Age { get; set; }
    public required string Email { get; set; } 
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string ProfilePhotoUrl { get; set; }
    public required Gender GenderU { get; set; }

}
    public enum Gender
    {
        Male,
        Female
    }