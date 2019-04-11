using Microsoft.Extensions.Logging;
using ParkingAvailbility.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAvailability.Grains
{
    public class SensorGrain : Orleans.Grain, ISensor
    {
        private bool Occupied { get; set; }

        private IParkingLocation Owner { get; set; }

        private Tuple<decimal, decimal> Coordinates { get; set; }

        private readonly ILogger _logger;

        public SensorGrain(ILogger<SensorGrain> logger)
        {
            _logger = logger;
        }


        public Task<Tuple<decimal, decimal>> GetCoordinates()
        {
            _logger.LogInformation("Getting coordinates for sensor: {0}", this.IdentityString);

            return Task.FromResult(Coordinates);
        }

        public Task<bool> GetOccupied()
        {
            _logger.LogInformation("Getting status for sensor: {0}", this.IdentityString);

            return Task.FromResult(Occupied);
        }

        public async Task<string> GetOwner()
        {
            _logger.LogInformation("Getting owner for sensor: {0}", this.IdentityString);

            return await Owner.GetName();
        }

        public Task SetCoordinates(decimal longitude, decimal latitude)
        {
            _logger.LogInformation("Setting coordinates for sensor: {0}, values -> long: {1}, lat: {2}", this.IdentityString, longitude, latitude);

            Coordinates = new Tuple<decimal, decimal>(longitude, latitude);

            return Task.CompletedTask;
        }

        public Task SetOccupied(bool occupied)
        {
            _logger.LogInformation("Setting sensor {0} occupied value: {1}", this.IdentityString, occupied);

            Occupied = occupied;

            return Task.CompletedTask;
        }

        public Task SetOwner(IParkingLocation owner)
        {
            _logger.LogInformation("Setting sensor {0} owner to: {1}", this.IdentityString, owner.GetName());

            Owner = owner;

            return Task.CompletedTask;
        }

        public Task<string> GetSummary()
        {
            _logger.LogInformation("Displaying summary for parking sensor");

            var sb = new StringBuilder();
            sb.AppendLine($"---Summary for sensor: {this.IdentityString}");
            sb.AppendLine($"---Occupied status: {Occupied}");
            sb.AppendLine($"---Owner: {Owner}");
            sb.AppendLine($"---Location -> long: {Coordinates.Item1}, lat: {Coordinates.Item2}");

            return Task.FromResult(sb.ToString());
        }
    }
}
