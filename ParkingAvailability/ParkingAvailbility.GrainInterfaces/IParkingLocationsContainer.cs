using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAvailbility.GrainInterfaces
{
    public interface IParkingLocationsContainer : Orleans.IGrainWithIntegerKey
    {

        Task AddParkingLocation(IParkingLocation parkingLocation);

        Task RemoveParkingLocation(IParkingLocation parkingLocation);

        Task<IEnumerable<IParkingLocation>> GetParkingLocations();

        Task<string> GetSummary();
    }
}
