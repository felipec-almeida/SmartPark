using FluentValidation;
using SmartPark.Borders.Dtos.ParkingLot;
using SmartPark.Borders.Shared.Messages;

namespace SmartPark.Borders.Validators.ParkingLot
{
    public class ParkingLotAddressValidator : AbstractValidator<ParkingLotAddressDto>
    {
        public ParkingLotAddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage(ValidationMessages.StreetRequired);

            RuleFor(x => x.Number)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.NumberPositive);

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage(ValidationMessages.CityRequired);

            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage(ValidationMessages.StateRequired);

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .WithMessage(ValidationMessages.ZipCodeRequired)
                .Matches(@"^\d{5}-\d{3}$")
                .WithMessage(ValidationMessages.ZipCodeInvalidFormat);
        }
    }
}
