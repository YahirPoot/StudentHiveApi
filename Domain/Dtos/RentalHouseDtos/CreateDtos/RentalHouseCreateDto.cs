namespace StudentHive.Domain.Dtos;

public class RentalHouseCreateDTO{ 
        public string ID_User { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int RentPrice { get; set; }
        public List<string> Image_Url_P { get; set; } = null!;
        public RentalHouseDetailCreateDTO DetailRentalHouse { get; set; } = null!;
        public HouseServiceCreateDTO HouseService { get; set; } = null!;
        public HouseLocationCreateDTO HouseLocation { get; set; } = null!;
        public List<ImageRentalHouseCreateDTO> Images { get; set; } = new ();
}





