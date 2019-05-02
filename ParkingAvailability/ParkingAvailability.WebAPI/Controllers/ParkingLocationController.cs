using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using ParkingAvailbility.GrainInterfaces;

namespace ParkingAvailability.WebAPI.Controllers
{
    public struct ParkingLocation
    {
        public string id { get; set; }

        public string store { get; set; }

        public string[] coordinates { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLocationController : Controller
    {
        private readonly IClusterClient _client;

        public ParkingLocationController(IClusterClient clusterClient)
        {
            _client = clusterClient;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var parkingLocations = await _client.GetGrain<IParkingLocationsContainer>(0).GetParkingLocations();

            return Json(parkingLocations);     
        }

        [HttpGet("Sensors")]
        public async Task<JsonResult> Sensors(string id)
        {
            if (id == null)
                return Json(null);

            var sensors = await _client.GetGrain<IParkingLocation>(id).GetSensors();
            return Json(sensors);
        }


        [HttpGet("Coordinates")]
        public async Task<JsonResult> Coordinates(string id)
        {
            if (id == null)
                return Json(null);

            var parkingLocation = await _client.GetGrain<IParkingLocation>(id).GetLocation();
            return Json(parkingLocation);
        }

        [HttpPost]
        public async Task<string> Post(ParkingLocation parkingLocation)
        {
            IParkingLocationsContainer parkingLocationsContainer = _client.GetGrain<IParkingLocationsContainer>(0);

            IParkingLocation pl = _client.GetGrain<IParkingLocation>(parkingLocation.id);
            await pl.SetLocation(decimal.Parse(parkingLocation.coordinates[0], CultureInfo.InvariantCulture), decimal.Parse(parkingLocation.coordinates[1], CultureInfo.InvariantCulture));

            var locations = await pl.GetLocation();

            await parkingLocationsContainer.AddParkingLocation(pl);

            return "Added";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}