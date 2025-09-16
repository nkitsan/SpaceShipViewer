namespace SpaceShipViewer.SpaceX.RestAPI.DTOs
{
    public class LaunchDetailsDTO
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string FlightNumber { get; set; }

        public required DateTime DateUTC { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool Success { get; set; }
    }
}
