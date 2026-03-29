using FluentValidation;
using HotelBooking.Application.Features.Amenities.Commands.Requests;
using HotelBooking.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Amenities.Commands.Validators
{
    public class CreateAmenityValidiator : AbstractValidator<CreateAmenityCommand>
    {
        public CreateAmenityValidiator()
        {
            RuleFor(ca => ca.Name)
                .RequiredFields(nameof(CreateAmenityCommand.Name))
                .MaxLengthField(nameof(CreateAmenityCommand.Name), 100);
            RuleFor(ca => ca.Description)
                .RequiredFields(nameof(CreateAmenityCommand.Description))
                .MaxLengthField(nameof(CreateAmenityCommand.Description), 255);
        }
    }
}
