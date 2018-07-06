using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[Controller]")]
    public class BookingController : Controller
    {
        readonly IBookingRepository repository;
        public BookingController(IBookingRepository repository) => this.repository = repository;

        [HttpGet]
        public Task<IEnumerable<Booking>> Get() => repository.GetBookings();

        [HttpGet("{id}")]
        public Task<Booking> Get(int id) => repository.GetBooking(id);

        [HttpPost]
        public Task<Booking> Post([FromBody] Booking booking) => repository.AddBooking(new Booking
        {
            BookedOn = DateTimeOffset.Now,
            ClientName = booking.ClientName.Trim(),
            Location = booking.Location.Trim()
        });

        [HttpPut]
        public Task<Booking> Put([FromBody] Booking booking) => repository.UpdateBooking(booking);

        [HttpPatch("{id}")]
        public async Task<StatusCodeResult> Patch(int id, [FromBody] JsonPatchDocument<Booking> patch)
        {
            Booking booking = await Get(id);
            if (booking != null)
            {
                patch.ApplyTo(booking);
                await repository.PatchBooking(booking);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public Task Delete(int id) => repository.DeleteBooking(id);
    }
}