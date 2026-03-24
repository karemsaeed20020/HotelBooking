using FluentValidation;
using HotelBooking.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Validators.UserValidators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Name)
                .RequiredFields(nameof(CreateUserDTO.Name))
                .LengthBetweenField(nameof(CreateUserDTO.Name), 2, 50)
                .LettersOnlyField(nameof(CreateUserDTO.Name));

            RuleFor(r => r.Phone)
                .RequiredFields(nameof(CreateUserDTO.Phone))
                .PhoneField(nameof(CreateUserDTO.Phone));

            RuleFor(r => r.Email)
                .RequiredFields(nameof(CreateUserDTO.Email))
                .LengthBetweenField(nameof(CreateUserDTO.Email), 10, 50)
                .EmailField(nameof(CreateUserDTO.Email));

            RuleFor(r => r.Password)
                .RequiredFields(nameof(CreateUserDTO.Password))
                .MinLengthField(nameof(CreateUserDTO.Password), 8)
                .PasswordField(nameof(CreateUserDTO.Password));
        }
    }
}
