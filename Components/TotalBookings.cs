using System;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Models;
using BookingAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Components
{
    public class TotalBookings : ViewComponent
    {
        private readonly IBookingRepository repository;
        public TotalBookings(IBookingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTimeOffset from, DateTimeOffset till)
        {
            var totalBookings = await repository.GetBookingCount(from, till);

            return View(new TotalBookingsViewModel{ TotalBookings = totalBookings, From = from, Till = till});
        }
    }
}