using Microsoft.Extensions.Logging;
using ParkingAvailbility.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAvailability.Grains
{
    class ParkingLocationContainerGrain : Orleans.Grain, IParkingLocationsContainer
    {
        private List<IParkingLocation> ParkingLocations { get; set; }

        private readonly ILogger _logger;

        public ParkingLocationContainerGrain(ILogger<ParkingLocationContainerGrain> logger)
        {
            _logger = logger;
            ParkingLocations = new List<IParkingLocation>();
        }

        public Task AddParkingLocation(IParkingLocation parkingLocation)
        {
            _logger.LogInformation("Adding new parking location");

            ParkingLocations.Add(parkingLocation);

            return Task.CompletedTask;
        }

        public Task RemoveParkingLocation(IParkingLocation parkingLocation)
        {
            _logger.LogInformation("Removing parking location");

            ParkingLocations.Remove(parkingLocation);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<IParkingLocation>> GetParkingLocations()
        {
            _logger.LogInformation("Getting all parking locations...");

            return Task.FromResult(ParkingLocations as IEnumerable<IParkingLocation>);
        }

        public Task<string> GetSummary()
        {
            _logger.LogInformation("Displaying summary for parking locations");

            var sb = new StringBuilder();
            sb.AppendLine($"---Parking location container holding references to {ParkingLocations.Count} parking location grains");

            return Task.FromResult(sb.ToString());
        }
    }
}
