using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_core.Models
{
    public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Name must contain only letters, numbers, dash and underscores.")]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(5,2)")]
        public decimal Weight { get; set; }
        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Code must contain only capital letters, numbers and underscore.")]
        public string Code { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int? DroneId { get; set; } 
        public Drone? Drone { get; set; }
    }
}
