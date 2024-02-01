namespace StudentHive.Domain.Dtos;

public class RentalHouseCreateDTO{
        public string Title { get; set; } = null!;
        public List<string> Image_Url_P { get; set; } = null!;
        public int NumberOfRooms { get; set; }
        public string? Description { get; set; }
        public bool OwnHouse { get; set; }
        public bool SharedRoom { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfBathrooms { get; set; }
        public LocationDTO Location { get; set; } = null!;
        public int RentPrice { get; set; }
        public HouserServiceDTO Service { get; set; } = null!;
        public int ID_User { get; set; }    
}





