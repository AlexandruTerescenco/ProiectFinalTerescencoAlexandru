using Proiect_Final_TerescencoAlexandru.DB;
using Microsoft.AspNetCore.Mvc;

namespace AlexandruBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Account()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null) 
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = _context.Users.FirstOrDefault(u => u.user_Id ==  userId);

            if (user == null) 
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(user);
        }
    }
}
