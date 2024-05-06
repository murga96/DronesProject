using drones_business.Services;
using drones_core.Dtos;
using drones_core.Models;
using DronesWebApi.Dtos;
using FluentValidation;

namespace DronesWebApi.ApiServices
{
    public class DroneApiService : IApiService
    {
        private readonly IDroneService _service;
        private readonly IMedicineService _medicineService;
        private readonly IValidator<DroneApiDto> _validator;
        private readonly IValidator<ChargeDroneWithMedicinesDto> _validatorMedicines;
        public DroneApiService(IDroneService service, IMedicineService medicineService, IValidator<DroneApiDto> validator,
            IValidator<ChargeDroneWithMedicinesDto> validatorMedicines) { 
            _service = service;
            _medicineService = medicineService;
            _validator = validator;
            _validatorMedicines = validatorMedicines;
        }

        public async Task<IResult> CreateDrone(DroneApiDto d)
        {
            var result = await _validator.ValidateAsync(d);
            if (!result.IsValid)
            {
                return TypedResults.ValidationProblem(result.ToDictionary());
            }
            if(_service.isSerialNumberExists(d.SerialNumber))
                return TypedResults.BadRequest($"Serial number {d.SerialNumber} already exists.");
            Drone newDrone = new()
            {
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                WeightLimit = d.WeightLimit,
                BatteryCapacity = d.BatteryCapacity,
                Status = DroneStatus.INACTIVE,
            };
            var drone = await _service.CreateDrone(newDrone);
            if (drone is null) return TypedResults.Problem("Drone wasn't created");
            return TypedResults.Created($"drones/{drone.Guid}",d);
        }

        public async Task<IResult> ChargeDroneWithMedicines(string guid, ChargeDroneWithMedicinesDto dto)
        {
            var result = await _validatorMedicines.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return TypedResults.ValidationProblem(result.ToDictionary());
            }

            DroneDto? drone = _service.GetDroneByGuid(guid);
            if (drone is null) 
                return TypedResults.NotFound($"No drone found with guid: {guid}");
            if (drone is not { Status: DroneStatus.INACTIVE }) 
                return TypedResults.BadRequest("Drone is not inactive, so it can't charge medicines");
            if (drone.BatteryCapacity < 25) 
                return TypedResults.BadRequest("Drone doesn't has enought battery power to charge medicines");
            
            if(dto.Medicines.Any(x => _medicineService.isCodeExists(x.Code))) {
                return TypedResults.BadRequest("Medicines to be charged must have unique code");
            }
            var totalWeightToCharge = dto.Medicines.Sum(x => x.Weight);
            if (totalWeightToCharge > drone.WeightLimit || ( drone.Medicines.Sum(x => x.Weight) + totalWeightToCharge > drone.WeightLimit) )
                return TypedResults.BadRequest("The load is too heavy, it exceeds the drone weight limit.");
            var newMedicines = dto.Medicines.Select(x => new Medicine()
            {
                Code = x.Code,
                Name = x.Name,
                Image = x.Image,
                Weight = x.Weight,
            });
            var resultChargeMedicines = _service.AddMedicines(guid, newMedicines.ToList());
            if(!resultChargeMedicines)
                return TypedResults.Problem("Drone wasn't charged with medicines");
            return TypedResults.Ok();
        }


        public async Task<List<DroneDto>> GetDrones()
        {
            var drones = await _service.GetDrones();
            return drones.ToList();
        }

        public List<DroneDto> GetAvailableDrones()
        {
            return _service.GetAvailableDrones().ToList();
        }

        public IResult GetDroneByGuid(string guid)
        {
            DroneDto? drone = _service.GetDroneByGuid(guid);
            if (drone is null) return TypedResults.NotFound($"No drone found with guid: {guid}");
            return TypedResults.Ok(drone);
        }

        public IResult GetDroneBatteryByGuid(string guid)
        {
            DroneDto? drone = _service.GetDroneByGuid(guid);
            if (drone is null) return TypedResults.NotFound($"No drone found with guid: {guid}");
            if (drone.BatteryCapacity < 0 && drone.BatteryCapacity > 100)
                return TypedResults.BadRequest($"Drone with guid {guid} has an invalid battery value");
            return TypedResults.Ok(new
            {
                battery = drone.BatteryCapacity
            });
        }

        public IResult GetDroneMedicineWeightByGuid(string guid)
        {
            DroneDto? drone = _service.GetDroneByGuid(guid);
            if (drone is null) return TypedResults.NotFound($"No drone found with guid: {guid}");
            decimal totalMedicineWeight = _service.GetTotalMedicinesWeight(drone);
            if (totalMedicineWeight > drone.WeightLimit)
                return TypedResults.BadRequest($"Drone with guid {guid} has more medicines that it can carry");
            return TypedResults.Ok(new
            {
                TotalMedicinesWeight = totalMedicineWeight
            });
        }

    }
}
