using drones_core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_core.Dtos
{
    public class DroneDto
    {
        public string Guid { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public DroneModel Model { get; set; }
        public decimal WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }
        public DroneStatus Status { get; set; }
        public ICollection<MedicineDto> Medicines { get; set; } = new List<MedicineDto>();
    }
}
