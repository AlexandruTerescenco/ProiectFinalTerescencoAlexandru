using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ActionResult Review()
        {
            return View();
        }

        //View Review Page
        [HttpGet]
        public ActionResult ViewReview(string name) 
        {
            var game = _context.games.FirstOrDefault(g => g.Name == name);
            game.Screenshot = _context.Screenshots.FirstOrDefault(s => s.screenshot_Id == game.screenshot_id);
            //game.Screenshot = (Screenshot)_context.Screenshots.Where(s => s.screenshot_Id == game.screenshot_id)
            //    .Select(s => new
            //    {
            //        s.image_1, 
            //        s.image_2,
            //        s.image_3,
            //        s.image_4,
            //        s.image_5,
            //        s.image_6,
            //        s.image_7,
            //        s.image_8,
            //        s.image_9,
            //        s.image_10
            //    });

            if (game != null)
            {
                HttpContext.Session.SetInt32("GameId", game.Id);
                return View("Review", game);
            }
            else
            {
                ModelState.AddModelError("", "Invalid game");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
