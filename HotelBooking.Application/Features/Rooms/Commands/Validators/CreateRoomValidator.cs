using FluentValidation;
using HotelBooking.Application.Features.Rooms.Commands.Requests;
using HotelBooking.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.Rooms.Commands.Validators
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomValidator()
        {
            RuleFor(cr => cr.RoomNumber)
                .RequiredFields(nameof(CreateRoomCommand.RoomNumber))
                .MaxLengthField(nameof(CreateRoomCommand.RoomNumber), 10)
                .NumbersOnlyField(nameof(CreateRoomCommand.RoomNumber));

            RuleFor(cr => cr.RoomTypeID).RequiredNumberField(nameof(CreateRoomCommand.RoomTypeID));


            RuleFor(cr => cr.RoomTypeID).RequiredNumberField(nameof(CreateRoomCommand.RoomTypeID));
            RuleFor(cr => cr.Price).PriceField(nameof(CreateRoomCommand.Price));
            
            RuleFor(cr => cr.BedType)
                .RequiredFields(nameof (CreateRoomCommand.BedType))
                .MaxLengthField(nameof(CreateRoomCommand.BedType), 10);

            RuleFor(cr => cr.ViewType)
                .RequiredFields (nameof (CreateRoomCommand.ViewType))
                .MaxLengthField(nameof(CreateRoomCommand.ViewType), 10);

            RuleFor(cr => cr.Status).EnumField(nameof(CreateRoomCommand.Status));
        }
    }
}
