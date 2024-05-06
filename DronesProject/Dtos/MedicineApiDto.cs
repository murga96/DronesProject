using Microsoft.AspNetCore.Mvc;

namespace DronesWebApi.Dtos
{
    public class MedicineApiDto
    {
        public string Name { get; set; } = null!;
        public decimal Weight { get; set; }
        public string Code { get; set; } = null!;
        public string Image { get; set; } = null!;
    }

    public class ChargeDroneWithMedicinesDto
    {
        public string Guid { get; set; } = null!;
        public List<MedicineApiDto> Medicines { get; set; } = []; 
    }
}
