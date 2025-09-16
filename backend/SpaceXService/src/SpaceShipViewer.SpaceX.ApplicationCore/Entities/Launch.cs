namespace SpaceShipViewer.SpaceX.ApplicationCore.Entities
{
    public class Launch
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string Details { get; set; }

        public uint? FlightNumber { get; set; }

        public DateTime? DateUTC { get; set; }

        public bool? Success { get; set; }
    }
}
