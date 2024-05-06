using drones_core.Dtos;
using drones_core.Models;

namespace drones_data.Repositories
{
    public interface IDroneRepository
    {
        Task<Drone?> CreateDrone(Drone drone);
        bool AddMedicines(Drone drone, ICollection<Medicine> medicines);
        ICollection<Drone> GetAvailableDrones();
        Drone? GetDroneByGuid(string guid);
        Drone? GetDroneById(int id);
        Task<ICollection<Drone>> GetDrones();
        decimal GetTotalMedicinesWeight(DroneDto drone);
        bool isSerialNumberExists(string serialNumber);
    }
}
