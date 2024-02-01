namespace StudentHive.Domain.Entities;

public class TypeHouseRental
{
    public int ID_TypeHouseRental { get; set; }
    public bool OwnHouse { get; set; }
    public bool SharedRoom { get; set; }
    public bool SingleRoom { get; set; }
}