using drones_core.Dtos;
using drones_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_data.Repositories
{
    public interface IDroneRepository
    {
        Task<Drone?> CreateDrone(Drone drone);
        bool AddMedicines(Drone drone, ICollection<Medicine> medicines);
        ICollection<Drone> GetAvailableDrones();
        DroneDto? GetDroneByGuid(string guid);
        DroneDto? GetDroneById(int id);
        Task<ICollection<DroneDto>> GetDrones();
        decimal GetTotalMedicinesWeight(Drone drone);
    }
}
