using FluentValidation;
using HotelBooking.Application.Features.Countries.Commands.Requests;
using HotelBooking.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Countries.Commands.Validators
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryValidator()
        {
            RuleFor(c => c.CountryId)
                .RequiredNumberField(nameof(UpdateCountryCommand.CountryId));
            RuleFor(c => c.CountryName)
                .RequiredFields(nameof(UpdateCountryCommand.CountryName))
                .MaxLengthField(nameof(UpdateCountryCommand.CountryName), 50);
            RuleFor(c => c.CountryCode)
                .RequiredFields(nameof(UpdateCountryCommand.CountryCode))
                .MaxLengthField(nameof(UpdateCountryCommand.CountryCode), 10);
        }
    }
}
