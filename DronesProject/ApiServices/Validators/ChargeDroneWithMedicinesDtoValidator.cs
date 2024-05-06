using DronesWebApi.Dtos;
using FluentValidation;

namespace DronesWebApi.ApiServices.Validators
{
    public class ChargeDroneWithMedicinesDtoValidator : AbstractValidator<ChargeDroneWithMedicinesDto>
    {
        public ChargeDroneWithMedicinesDtoValidator()
        {
            RuleForEach(x => x.Medicines).NotNull().SetValidator(new MedicineApiDtoValidator());
        }
    }
}
