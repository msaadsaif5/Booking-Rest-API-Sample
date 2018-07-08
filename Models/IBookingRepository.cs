using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingAPI.Models
{
    public interface IBookingRepository
    {
         Task<Booking> GetBooking(long bookingId);
         Task<int> GetBookingCount(DateTimeOffset from, DateTimeOffset till);
         Task<IEnumerable<Booking>> GetBookings();
         Task<Booking> AddBooking(Booking booking);
         Task<Booking> UpdateBooking(Booking booking);
         Task DeleteBooking(long bookingId);
         Task PatchBooking(Booking booking);
    }
}