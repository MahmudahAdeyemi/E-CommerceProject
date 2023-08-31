using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Services;
using E_Commerce_2.RequestModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
namespace E_Commerce_2.Controllers
{

    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;

        public UserController(IMapper mapper, UserManager<User> userManager, IUserService userService, ICustomerService customerService, IAdminService adminService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userService = userService;
            _customerService = customerService;
            _adminService = adminService;
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(UserRequestModel userRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRequestModel);
            }
            var user = _userService.AddUser(userRequestModel);
           await _adminService.AddAdmin(userRequestModel);
            var result = await _userManager.CreateAsync(user, userRequestModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                TempData["ErrorMessage"] = "There was an error creating the user.";
                return View(userRequestModel);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRequestModel userRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRequestModel);
            }
            var user = _userService.AddUser(userRequestModel);
            var result = await _userManager.CreateAsync(user, userRequestModel.Password);
            _customerService.AddCustomer(userRequestModel);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                TempData["ErrorMessage"] = "There was an error creating the user.";
                return View(userRequestModel);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginCustomerRequest loginCustomerRequest)
        {
            var user = await _userService.CheckCustomer(loginCustomerRequest);
            if (user is null)
            {
                return BadRequest("Invalid credentials.");
            }
            var claims = new List<Claim>
            {
                new Claim(type: ClaimTypes.Email, value: user.email),
                new Claim(type: ClaimTypes.Name,value: user.Password)
            };
            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                });
            return RedirectToAction("Index", "Home");
        }

    }
}