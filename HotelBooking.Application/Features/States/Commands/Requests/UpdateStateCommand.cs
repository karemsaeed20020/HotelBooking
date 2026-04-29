using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Features.States.Commands.Requests
{
    public class UpdateStateCommand
    {
        public int StateId { get; set; }
        public string StateName { get; set; } = default!;
        public int CountryID { get; set; }
    }
}
