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

        Drone? IDroneRepository.GetDroneByGuid(string guid)
        {
            return _context.Drones.Include(x => x.Medicines).FirstOrDefault(x => x.Guid == guid);
        }

        Drone? IDroneRepository.GetDroneById(int id)
        {
            return _context.Drones.Include(x => x.Medicines).FirstOrDefault(x => x.Id == id);
        }

        async Task<ICollection<Drone>> IDroneRepository.GetDrones()
        {
            return await _context.Drones.Include(x => x.Medicines).ToListAsync();
        }

        decimal IDroneRepository.GetTotalMedicinesWeight(Drone drone)
        {
            if (drone is null) return (decimal)-1.0;
            return drone.Medicines.Sum(d => d.Weight);
        }
    }
}
