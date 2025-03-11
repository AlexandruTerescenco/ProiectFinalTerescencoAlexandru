using Proiect_Final_TerescencoAlexandru.DB;
using Proiect_Final_TerescencoAlexandru.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlexandruBlog.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        //1. ShowLogin
        public ActionResult ShowLogin()
        {
            return View(); //View : Auth/ShowLogin
        }

        //2. Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user != null) 
            {
                //bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (password == user.Password) 
                {
                    HttpContext.Session.SetInt32("UserId", user.user_Id);
                    HttpContext.Session.SetString("UserRole", user.Role);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            else
            {
                ModelState.AddModelError("", "Null Invalid username or password");
            }

            return View("ShowLogin");

        }

        //3.Register
        [HttpPost]
        public async Task<ActionResult> Register(string username, string email, string password, string confirm_password)
        {
            if (password != confirm_password) 
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View();
            }

            //string hasedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                image = "",
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("ShowLogin", "Auth");
        }

        //4.ShowRegister
        public ActionResult ShowRegister()
        {
            return View();
        }

        //5. Logout
        public ActionResult Logout() 
        {
            if (HttpContext.Session != null) 
            {
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
