using Microsoft.EntityFrameworkCore;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.Infrastructure
{
    public class SpaceXDbContext : DbContext
    {
        public SpaceXDbContext(DbContextOptions<SpaceXDbContext> options)
        : base(options)
        {
        }

        public DbSet<Launch> Launches { get; set; }
    }
}
