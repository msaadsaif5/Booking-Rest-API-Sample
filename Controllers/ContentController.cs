using System;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "This is a string response";

        [HttpGet("object")]
        //[Produces("application/json")]
        public Booking GetObject() => new Booking { BookingId = 100, ClientName = "Joe", Location = "Board Room", BookedOn = DateTimeOffset.Now };

        [HttpPost]
        [Consumes("application/json")]
        public Booking SaveBookingJson(Booking booking){
          return new Booking{ BookingId = 1, ClientName = "json" };
        }
        
        [HttpPost]
        [Consumes("application/xml")]
        public Booking SaveBookingXml(Booking booking){
          return new Booking{ BookingId = 1, ClientName = "xml" };
        }
    }
}