namespace StudentHive.Domain.Entities;

public class HouseLocation
    {
        public int ID_Location { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public required string PostalCode { get; set; }
        public required string Neighborhood  { get; set; }
    }