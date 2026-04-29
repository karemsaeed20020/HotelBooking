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
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryValidator()
        {
            RuleFor(c => c.CountryName)
                .RequiredFields(nameof(CreateCountryCommand.CountryName))
                .MaxLengthField(nameof(CreateCountryCommand.CountryName), 50);
            RuleFor(c => c.CountryCode)
                .RequiredFields(nameof(CreateCountryCommand.CountryCode))
                .MaxLengthField(nameof(CreateCountryCommand.CountryCode), 10);
        }
    }
}
