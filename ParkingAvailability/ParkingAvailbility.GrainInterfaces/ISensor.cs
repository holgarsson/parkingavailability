using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingAvailbility.GrainInterfaces
{
    public interface ISensor : Orleans.IGrainWithStringKey
    {
        Task SetOccupied(bool occupied);

        Task SetOwner(IParkingLocation owner);

        Task SetCoordinates(decimal longitude, decimal latidude);

        Task<Tuple<decimal, decimal>> GetCoordinates();

        Task<string> GetOwner();

        Task<bool> GetOccupied();

        Task<string> GetSummary();
    }
}
