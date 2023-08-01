using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Services;
using E_Commerce_2.RequestModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_2.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, UserManager<User> userManager,IUserService userService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userService = userService;
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
            if(!ModelState.IsValid)
            {
                return View(userRequestModel);
            }
            var user = _userService.AddUser(userRequestModel);
            var result = await _userManager.CreateAsync(user, userRequestModel.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userRequestModel);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index", "Home");
        }
    }
}