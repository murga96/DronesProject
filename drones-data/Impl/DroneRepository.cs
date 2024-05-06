using drones_core.Dtos;
using drones_core.Models;
using drones_data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_data.Impl
{
    public class DroneRepository : IDroneRepository
    {
        private readonly AppDbContext _context;
        public DroneRepository(AppDbContext context)
        {
            _context = context;
        }
        bool IDroneRepository.AddMedicines(Drone drone, ICollection<Medicine> medicines)
        {
            if (drone is null) return false;
            drone.Medicines = medicines;
            drone.Status = DroneStatus.CHARGED;
            _context.SaveChanges();
            return true;
        }

        async Task<Drone?> IDroneRepository.CreateDrone(Drone drone)
        {
            await _context.AddAsync(drone);
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? drone : null;
        }

        ICollection<Drone> IDroneRepository.GetAvailableDrones()
        {
            return _context.Drones.Where(x => x.BatteryCapacity > 25 && (x.Status == DroneStatus.INACTIVE)).Include(x => x.Medicines).ToList();
        }

        DroneDto? IDroneRepository.GetDroneByGuid(string guid)
        {
            Drone? d = _context.Drones.Include(x => x.Medicines).FirstOrDefault(x => x.Guid == guid);
            return d is null ? null : new DroneDto()
            {
                Guid = d.Guid,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = d.Status,
                Medicines = d.Medicines,
            };
        }

        DroneDto? IDroneRepository.GetDroneById(int id)
        {
            Drone? d = _context.Drones.Include(x => x.Medicines).FirstOrDefault(x => x.Id == id);
            return d is null ? null : new DroneDto()
            {
                Guid = d.Guid,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = d.Status,
                Medicines = d.Medicines,
            };
        }

        async Task<ICollection<DroneDto>> IDroneRepository.GetDrones()
        {
            var drones = await _context.Drones.Include(x => x.Medicines).ToListAsync();
            return drones.Select(d => new DroneDto()
            {
                Guid = d.Guid,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = d.Status,
                Medicines = d.Medicines,
            }).ToList();
        }

        decimal IDroneRepository.GetTotalMedicinesWeight(Drone drone)
        {
            if (drone is null) return (decimal)-1.0;
            return drone.Medicines.Sum(d => d.Weight);
        }
    }
}
