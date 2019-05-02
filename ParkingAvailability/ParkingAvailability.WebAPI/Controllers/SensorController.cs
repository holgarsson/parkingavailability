using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Orleans;
using ParkingAvailbility.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAvailability.WebAPI.Controllers
{
    public struct Sensor
    {
        public string Id { get; set; }

        public string Owner { get; set; }

        public string Owner_id { get; set; }

        public string[] Coordinates { get; set; }

        public string Occupied { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : Controller
    {
        private readonly IClusterClient _client;
        private readonly ILogger _logger;

        public SensorController(IClusterClient clusterClient, ILogger<SensorController> logger)
        {
            _client = clusterClient;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return "Hello World!";
        }

        [HttpGet("Coordinates")]
        public async Task<JsonResult> Coordinates(string id)
        {
            if (id == null)
                return Json(null);

            Tuple<decimal, decimal> sensorCoordinates = await _client.GetGrain<ISensor>(id).GetCoordinates();

            return Json(sensorCoordinates);
        }

        [HttpPost("Occupied")]
        public async Task<string> Occupied(string Id, bool? Occupied)
        {
            if (Id == null || !Occupied.HasValue)
                return string.Empty;

            await _client.GetGrain<ISensor>(Id).SetOccupied(Occupied.Value);

            return $"Occupied status for id: {Id} set to: {Occupied.Value}";
        }


        [HttpGet("Occupied")]
        public async Task<JsonResult> Occupied(string id)
        {
            if (id == null)
                return Json(null);

            bool sensorOccupied = await _client.GetGrain<ISensor>(id).GetOccupied();

            return Json(sensorOccupied);
        }

        [HttpGet("Owner")]
        public async Task<JsonResult> Owner(string id)
        {
            if (id == null)
                return Json(null);

            string owner = await _client.GetGrain<ISensor>(id).GetOwner();

            return Json(owner);
        }

        [HttpGet("GetSummary")]
        public async Task<JsonResult> Summary(string id)
        {
            if (id == null)
                return Json(null);

            string summary = await _client.GetGrain<ISensor>(id).GetSummary();

            return Json(summary);
        }


        [HttpPost]
        public async Task<string> Post(dynamic jsonSensor)
        {
            string sensorId = jsonSensor.Id;
            string owner = jsonSensor.Owner;
            string owner_id = jsonSensor.Owner_id;
            string coordinatesRaw = jsonSensor.Coordinates;
            string[] coordinates = coordinatesRaw.Trim('(').Trim(')').Split(',');
            string occupied = jsonSensor.Occupied;

            Sensor sensor = new Sensor
            {
                Id = sensorId,
                Owner = owner,
                Owner_id = owner_id,
                Coordinates = coordinates,
                Occupied = occupied
            };

            var sensorReference = _client.GetGrain<ISensor>(sensor.Id);
            
            var parkingLocation = _client.GetGrain<IParkingLocation>(sensor.Owner_id);
            await parkingLocation.AddSensor(sensorReference);

            await sensorReference.SetOwner(parkingLocation);
            await sensorReference.SetOccupied(bool.Parse(sensor.Occupied));
            await sensorReference.SetCoordinates(decimal.Parse(coordinates[0]), decimal.Parse(coordinates[1]));

            return "Sensor added";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        private string[] GetCoordinates(string coordinates)
        {
            string[] cords = new string[1];

            string[] coordinatesSplit = coordinates.Trim('(').Trim(')').Split(',');

            return cords;
        }
    }
}
