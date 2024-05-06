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
    public class MedicineDto
    {
        public string Guid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Weight { get; set; }
        public string Code { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
