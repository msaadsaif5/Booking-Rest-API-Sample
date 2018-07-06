using System;

namespace BookingAPI.Models
{
    public class Booking
    {
        public long BookingId { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
        public DateTimeOffset BookedOn { get; set; }
    }
}