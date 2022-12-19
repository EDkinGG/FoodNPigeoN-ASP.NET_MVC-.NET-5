using FoodPigeoN.Data;
using FoodPigeoN.Data.StaticRole;
using FoodPigeoN.Data.ViewModels;
using FoodPigeoN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FoodPigeoN.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context; 
        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync(); 
            return View(users);
        }

        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Foods");
                    }
                }
                TempData["Error"] = "Wrong Info given. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong Info given. Please, try again!";
            return View(loginVM);
        }



        public IActionResult SignUp()
        {
            var response = new SignUpVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM signupVM)
        {
            if (!ModelState.IsValid) return View(signupVM);

            var user = await _userManager.FindByEmailAsync(signupVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already registered";
                return View(signupVM);
            }

            var newUser = new AppUser()
            {
                FullName = signupVM.FullName,
                Email = signupVM.EmailAddress,
                Address = signupVM.Address,
                PhoneNumber = signupVM.PhoneNumber,
                UserName = signupVM.UserName
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, signupVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            else
            {
                TempData["Error"] = "The Password must contain a digit, a lowercase alphabet, a Uppercase alphabet, a non-alphanumeric character(+,-,?) and the of length must be at least 6";
                return View(signupVM);
            }
                

            return View("SignUpDone");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Foods");
        }



    }
}
