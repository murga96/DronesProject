using DronesWebApi.Dtos;
using FluentValidation;

namespace DronesWebApi.ApiServices.Validators
{
    public class MedicineApiDtoValidator: AbstractValidator<MedicineApiDto>
    {
        public MedicineApiDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().Matches(@"^[a-zA-Z0-9_-]+$").WithMessage("{PropertyName} must contain only letters, numbers, dash and underscores.");
            RuleFor(x => x.Code).NotNull().Matches(@"^[A-Z0-9_]+$").WithMessage("{PropertyName} must contain only capital letters, numbers and underscore.");
            RuleFor(x => x.Weight).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}
