using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace drones_core.Models
{
    public enum DroneModel
    {
        LIGHT_WEIGHT,
        MIDDLE_WEIGHT,
        CRUISER_WEIGHT,
        HEAVY_WEIGHT,
    }
    public enum DroneStatus
    {
        INACTIVE,
        CHARGING,
        CHARGED,
        DELIVERING,
        DELIVERED,
        RETURNING,
    }
    public class Drone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        [MaxLength(100)]
        public string SerialNumber { get; set; } = null!;
        public DroneModel Model { get; set; }
        [Range(0.00, 500.00)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal WeightLimit { get; set; }
        [Range(0, 100)]
        public int BatteryCapacity { get; set; }
        public DroneStatus Status { get; set; }
        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    }
}
