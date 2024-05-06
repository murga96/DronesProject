using drones_business.Services;
using drones_core.Dtos;
using drones_core.Models;
using drones_data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_business.Impl
{
    public class DroneService : IDroneService
    {
        private readonly IDroneRepository _repository;
        public DroneService(IDroneRepository repository)
        {
            _repository = repository;
        }

        bool IDroneService.AddMedicines(string guid , ICollection<Medicine> medicines)
        {
            var drone = _repository.GetDroneByGuid(guid);
            if(drone is null) return false;
            return _repository.AddMedicines(drone, medicines);
        }

        async Task<Drone?> IDroneService.CreateDrone(Drone drone)
        {
            return await _repository.CreateDrone(drone);
        }

        ICollection<DroneDto> IDroneService.GetAvailableDrones()
        {
            return _repository.GetAvailableDrones().Select(d => new DroneDto()
            {
                Guid = d.Guid,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = d.Status,
                Medicines = d.Medicines.Select(m => new MedicineDto()
                {
                    Guid = m.Guid,
                    Name = m.Name,
                    Code = m.Code,
                    Weight = m.Weight,
                    Image = m.Image,
                }).ToList(),
            }).ToList();
        }

        DroneDto? IDroneService.GetDroneByGuid(string guid)
        {
            var d = _repository.GetDroneByGuid(guid);
            return d is null ? null : new DroneDto()
            {
                Guid = d.Guid,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = d.Status,
                Medicines = d.Medicines.Select(m => new MedicineDto()
                {
                    Guid = m.Guid,
                    Name = m.Name,
                    Code = m.Code,
                    Weight = m.Weight,
                    Image = m.Image,
                }).ToList(),
            };
        }

        async Task<ICollection<DroneDto>> IDroneService.GetDrones()
        {
            var drones = await _repository.GetDrones();
            return drones.Select(d => new DroneDto()
            {
                Guid = d.Guid,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = d.Status,
                Medicines = d.Medicines.Select(m => new MedicineDto()
                {
                    Guid = m.Guid,
                    Name = m.Name,
                    Code = m.Code,
                    Weight = m.Weight,
                    Image = m.Image,
                }).ToList(),
            }).ToList();
        }

        decimal IDroneService.GetTotalMedicinesWeight(DroneDto drone)
        {
            return _repository.GetTotalMedicinesWeight(drone);
        }
    }
}
