namespace StudentHive.Domain.Entities;
    public class HouseService
    {
        public required int ServiceId { get; set; }
        public required bool Wifi { get; set; }
        public required bool Kitchen { get; set; }
        public required bool Washer { get; set; }
        public required bool AirConditioning { get; set; }
        public required bool Water { get; set; }
        public required bool Gas { get; set; }
        public required bool Television { get; set; }
        public required bool HammockHooks { get; set; }

    }
