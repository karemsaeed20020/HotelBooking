using FluentValidation;
using HotelBooking.Application.Features.States.Commands.Requests;
using HotelBooking.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.States.Commands.Validators
{
    public class CreateStateValidator : AbstractValidator<CreateStateCommand>
    {
        public CreateStateValidator()
        {
            RuleFor(s => s.StateName)
                .RequiredFields(nameof(CreateStateCommand.StateName))
                .MaxLengthField(nameof(CreateStateCommand.StateName), 100);
            RuleFor(s => s.CountryID)
                .RequiredNumberField(nameof(CreateStateCommand.CountryID));

        }
    }
}
