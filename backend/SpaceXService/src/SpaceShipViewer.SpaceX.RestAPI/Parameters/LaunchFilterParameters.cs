namespace SpaceShipViewer.SpaceX.RestAPI.Parameters
{
    public record LaunchFilterParameters(
        string? Name,
        DateTime? LauchFromDate,
        bool OrderByDesc = false);
}
