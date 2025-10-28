using FluentValidation;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Shared.Messages;

namespace SmartPark.Borders.Validators.ParkingLot
{
    public class PostParkingLotRequestValidator : AbstractValidator<PostParkingLotRequest>
    {
        public PostParkingLotRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ValidationMessages.NameRequired)
                .MaximumLength(100)
                .WithMessage(ValidationMessages.NameMaxLength);

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage(ValidationMessages.AddressRequired)
                .SetValidator(new ParkingLotAddressValidator());

            RuleFor(x => x.CarSpots)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ValidationMessages.CarSpotsNonNegative);

            RuleFor(x => x.MotorcycleSpots)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ValidationMessages.MotorcycleSpotsNonNegative);

        }
    }
}
