using drones_core.Dtos;
using drones_core.Models;

namespace DronesWebApi.Dtos
{
    public class DroneApiDto
    {
        public string SerialNumber { get; set; } = null!;
        public DroneModel Model { get; set; }
        public decimal WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }

    }
}
