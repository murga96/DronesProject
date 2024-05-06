using drones_core.Dtos;
using drones_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_business.Services
{
    public interface IDroneService
    {
        Task<Drone?> CreateDrone(Drone drone);
        bool AddMedicines(Drone drone, ICollection<Medicine> medicines);
        ICollection<DroneDto> GetAvailableDrones();
        DroneDto? GetDroneByGuid(string guid);
        Task<ICollection<DroneDto>> GetDrones();
        decimal GetTotalMedicinesWeight(Drone drone);
    }
}
