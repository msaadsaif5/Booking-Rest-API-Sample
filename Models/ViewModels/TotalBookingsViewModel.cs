using System;

namespace BookingAPI.Models.ViewModels
{
    public class TotalBookingsViewModel
    {
        public int TotalBookings { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset Till { get; set; }
    }
}