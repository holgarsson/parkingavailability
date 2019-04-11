using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using ParkingAvailbility.GrainInterfaces;

namespace ParkingAvailability.WebAPI.Controllers
{
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
        public void Post([FromBody] string value)
        {

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