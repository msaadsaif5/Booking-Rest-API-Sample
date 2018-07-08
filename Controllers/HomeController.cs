using System.Threading.Tasks;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    public class HomeController : Controller
    {
        private IBookingRepository repository { get; set; }
        public HomeController(IBookingRepository repo) => repository = repo;
        public async Task<ViewResult> Index() {
            return View(await repository.GetBookings());
        }

        public IActionResult TotalBookings(){
            return ViewComponent(nameof(TotalBookings));
        }
        
        [HttpPost]  
        public async Task<IActionResult> Book(Booking booking){
            var result = await repository.AddBooking(booking);
            return RedirectToAction("Index");
        }
    }
}