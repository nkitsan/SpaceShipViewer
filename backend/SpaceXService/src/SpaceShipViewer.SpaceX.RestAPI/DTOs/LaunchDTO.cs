namespace SpaceShipViewer.SpaceX.RestAPI.DTOs
{
    public record LaunchDTO
    {
        public required string Id { get; set; }

        public required string Name { get; set; }
    }
}
