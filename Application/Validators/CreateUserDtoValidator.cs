namespace SmartCity.Application.Validators;
using FluentValidation;
using Application.DTOs;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(4).WithMessage("Username must be at least 4 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required.");

        RuleFor(x => x.BuildingNumber)
            .NotEmpty().WithMessage("Building Number is required.");

        RuleFor(x => x.ApartmentNumber)
            .NotEmpty().WithMessage("Apartment Number is required.");
    }
}