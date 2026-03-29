using FluentValidation;
using HotelBooking.Application.Features.Amenities.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Amenities.Commands.Validators
{
    public class CreateAmenitiesValidator : AbstractValidator<CreateAmenitiesCommand>
    {
        private const int _maxAmenitiesCount = 10;
        public CreateAmenitiesValidator()
        {
            RuleFor(ca => ca.Amenities)
                .NotEmpty()
                .Must(ca => ca.Count <= _maxAmenitiesCount)
                .WithMessage($"Maximum allowed amenities is {_maxAmenitiesCount}");

            RuleForEach(ca => ca.Amenities)
                .SetValidator(new CreateAmenityValidiator());
        }
    }
}
