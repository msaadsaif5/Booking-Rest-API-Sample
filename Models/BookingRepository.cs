using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models
{
    public class BookingRepository: IBookingRepository
    {
        private readonly BookingContext context;
        public BookingRepository(BookingContext context)
        {
            this.context = context;
        }

        public async Task<Booking> GetBooking(long bookingId) => await context.Bookings.SingleOrDefaultAsync(b=>b.BookingId == bookingId);

        public async Task<Booking> AddBooking(Booking booking)
        {
            booking.BookedOn = DateTimeOffset.Now;
            var result = await context.AddAsync(booking);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteBooking(long bookingId)
        {
            var booking = await context.Bookings.SingleOrDefaultAsync(b=>b.BookingId == bookingId);
            context.Bookings.Remove(booking);
            await context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await context.Bookings.ToListAsync();
        }

        public async Task PatchBooking(Booking booking){
            //context.Entry(booking).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            var result = await context.Bookings.SingleOrDefaultAsync(b=>b.BookingId == booking.BookingId);
            result.ClientName = booking.ClientName.Trim();
            result.Location = booking.Location.Trim();
            await context.SaveChangesAsync();
            return result;
        }
    }
}