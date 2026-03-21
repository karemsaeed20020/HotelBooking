using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities.Payments
{
    public enum RefundStatus
    {
        Pending,
        Processed,
        Completed,
        Failed
    }
}
