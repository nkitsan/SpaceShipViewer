using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Entities
{
    public class Launch
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string FlightNumber { get; set; }

        public required DateTime DateUTC { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool Success { get; set; }
    }
}
