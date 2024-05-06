using drones_core.Models;
using DronesWebApi.Dtos;
using FluentValidation;

namespace DronesWebApi.ApiServices.Validators
{
    public class DroneDtoValidator: AbstractValidator<DroneApiDto>
    {
        public DroneDtoValidator() { 
            RuleFor(x => x.WeightLimit).NotNull().LessThanOrEqualTo(500);
            RuleFor(x => x.SerialNumber).NotEmpty().MaximumLength(100);
            RuleFor(x => x.BatteryCapacity).NotNull().InclusiveBetween(0, 100);
            RuleFor(x => x.Model).NotNull().IsInEnum();
        }
    }
}
