using DronesWebApi.Dtos;
using FluentValidation;

namespace DronesWebApi.ApiServices.Validators
{
    public class ChargeDroneWithMedicinesDtoValidator : AbstractValidator<ChargeDroneWithMedicinesDto>
    {
        public ChargeDroneWithMedicinesDtoValidator()
        {
            RuleFor(x => x.Medicines).NotEmpty();
            RuleFor(x => x.Guid).NotEmpty();
            RuleForEach(x => x.Medicines).NotNull().SetValidator(new MedicineApiDtoValidator());
        }
    }
}
