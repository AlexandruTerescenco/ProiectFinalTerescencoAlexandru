using Microsoft.AspNetCore.Mvc;
using Proiect_Final_TerescencoAlexandru.DB;
using Proiect_Final_TerescencoAlexandru.Models;

namespace Proiect_Final_TerescencoAlexandru.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        //1. Frostpunk 2 example page
        public ActionResult Review()
        {
            return View();
        }
    }
}
