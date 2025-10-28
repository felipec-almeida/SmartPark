using FluentValidation;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Shared.Messages;

namespace SmartPark.Borders.Validators.ParkingLot
{
    public class PatchParkingLotRequestValidator : AbstractValidator<PatchParkingLotRequest>
    {
        public PatchParkingLotRequestValidator()
        {
            When(x => x.Address is not null, () =>
            {
                RuleFor(x => x.Address!)
                .SetValidator(new ParkingLotAddressValidator());
            });

            When(x => x.CarSpots.HasValue, () =>
            {
                RuleFor(x => x.CarSpots!.Value)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage(ValidationMessages.CarSpotsNonNegative);
            });

            When(x => x.MotorcycleSpots.HasValue, () =>
            {
                RuleFor(x => x.MotorcycleSpots!.Value)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage(ValidationMessages.MotorcycleSpotsNonNegative);
            });

            When(x => x.Name is not null, () =>
            {
                RuleFor(x => x.Name!)
                .NotEmpty()
                .WithMessage(ValidationMessages.NameRequired);
            });
        }
    }
}
