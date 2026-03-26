using FluentValidation;
using HotelBooking.Application.Features.RoomTypes.Commands.Requests;
using HotelBooking.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.RoomTypes.Commands.Validators
{
    public class UpdateRoomTypeValidator : AbstractValidator<UpdateRoomTypeCommand>
    {
        public UpdateRoomTypeValidator()
        {
            RuleFor(ur => ur.RoomTypeId).RequiredNumberField(nameof(UpdateRoomTypeCommand.RoomTypeId));
            RuleFor(ur => ur.TypeName)
               .RequiredFields(nameof(UpdateRoomTypeCommand.TypeName))
               .MaxLengthField(nameof(UpdateRoomTypeCommand.TypeName), 50);


            RuleFor(ur => ur.AccessibilityFeatures)
                .RequiredFields(nameof(UpdateRoomTypeCommand.AccessibilityFeatures))
                .MaxLengthField(nameof(UpdateRoomTypeCommand.AccessibilityFeatures), 255);

            RuleFor(ur => ur.Description)
                .RequiredFields(nameof(UpdateRoomTypeCommand.Description))
                .MaxLengthField(nameof(UpdateRoomTypeCommand.Description), 255);
        }
    }
}
