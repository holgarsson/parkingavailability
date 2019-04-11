using Microsoft.Extensions.Logging;
using ParkingAvailbility.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAvailability.Grains
{
    public class ParkingLocationGrain : Orleans.Grain, IParkingLocation
    {
        private HashSet<ISensor> Sensors { get; set; }

        private Tuple<decimal, decimal> Coordinates { get; set; }

        private readonly ILogger _logger;

        public ParkingLocationGrain(ILogger<ParkingLocationGrain> logger)
        {
            _logger = logger;
            Sensors = new HashSet<ISensor>();
        }

        public Task SetLocation(decimal longitude, decimal latitude)
        {
            _logger.LogInformation("Setting coordinates -> long: {0}, lat: {1}", longitude, latitude);

            Coordinates = new Tuple<decimal, decimal>(longitude, latitude);

            return Task.CompletedTask;
        }

        public Task SetSensors(IEnumerable<ISensor> sensors)
        {
            _logger.LogInformation("Settings all sensors...");

            Sensors = sensors as HashSet<ISensor>;

            return Task.CompletedTask;
        }

        public Task AddSensor(ISensor sensor)
        {
            _logger.LogInformation("Adding new sensor to parking location");

            Sensors.Add(sensor);

            return Task.CompletedTask;
        }

        public Task RemoveSensor(ISensor sensor)
        {
            _logger.LogInformation("Removing sensor");

            Sensors.Remove(sensor);

            return Task.CompletedTask;
        }

        public Task<Tuple<decimal, decimal>> GetLocation()
        {
            _logger.LogInformation("Getting coordinats for parking location");

            return Task.FromResult(Coordinates);
        }

        public Task<IEnumerable<ISensor>> GetSensors()
        {
            _logger.LogInformation("Getting all sensors...");

            return Task.FromResult(Sensors as IEnumerable<ISensor>);
        }

        public Task<string> GetSummary()
        {
            _logger.LogInformation("Displaying summary for parking location");

            var sb = new StringBuilder();
            sb.AppendLine($"---Summary for parking location: {this.IdentityString}");
            sb.AppendLine($"---Sensor count: {Sensors.Count}");
            sb.AppendLine($"---Location -> long: {Coordinates.Item1}, lat: {Coordinates.Item2}");

            return Task.FromResult(sb.ToString());
        }

        public Task<string> GetName()
        {
            _logger.LogInformation("GetName() called");

            return Task.FromResult(this.IdentityString);
        }
    }
}
