using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_Final_TerescencoAlexandru.DB;
using Proiect_Final_TerescencoAlexandru.Models;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        //AddReview
        [HttpPost]
        public async Task<ActionResult> CreateReview(string name, string review, string mainImage, float score)
        {
            var Screenshots = new Screenshot();
            
            var alreadyExists = _context.games.FirstOrDefault(g => g.Name == name);

            var userId = HttpContext.Session.GetInt32("UserId");

            var user = _context.Users.FirstOrDefault(u => u.user_Id == userId);

            if (alreadyExists != null)
            { 
                ModelState.AddModelError("", "Review for this game already exists.");
                return View();
            }

            var game = new Game
            {
                Name = name,
                Review = review,
                Image = mainImage,
                //Screenshots = (ICollection<Screenshot>)Screenshots,
                Score = score,
                Reviewer = user.Username,
                screenshot_id = Screenshots.screenshot_Id
            };

            _context.Screenshots.Add(Screenshots);
            _context.games.Add(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddReview()
        {
            return View();
        }
    }
}
