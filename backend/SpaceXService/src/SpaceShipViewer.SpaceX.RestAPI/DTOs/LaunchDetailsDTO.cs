namespace SpaceShipViewer.SpaceX.RestAPI.DTOs
{
    public class LaunchDetailsDTO
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public string Details { get; set; } = string.Empty;

        public uint? FlightNumber { get; set; }

        public DateTime? DateUTC { get; set; }

        public bool? Success { get; set; }
    }
}
