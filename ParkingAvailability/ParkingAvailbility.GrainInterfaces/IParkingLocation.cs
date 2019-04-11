using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAvailbility.GrainInterfaces
{
    public interface IParkingLocation : Orleans.IGrainWithStringKey
    {
        Task SetLocation(decimal longitude, decimal latitude);

        Task SetSensors(IEnumerable<ISensor> sensors);

        Task AddSensor(ISensor sensor);

        Task RemoveSensor(ISensor sensor);

        Task<Tuple<decimal, decimal>> GetLocation();

        Task<IEnumerable<ISensor>> GetSensors();

        Task<string> GetSummary();
    }
}
