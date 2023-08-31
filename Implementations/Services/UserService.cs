using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Services;
using E_Commerce_2.RequestModel;
using E_Commerce_2.ResponseModel;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_2.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public User AddUser(UserRequestModel userRequestModel)
        {
            var user = _mapper.Map<User>(userRequestModel);
            return user;
        }
        public BaseResponse UserLogin (LoginCustomerRequest loginCustomerRequest)
        {
            if(_userManager.FindByEmailAsync(loginCustomerRequest.Email) != null)
            {
                return new BaseResponse()
                {
                    Message = "Sucessfully done",
                    Status = true
                };
            }
            
            return new BaseResponse()
            {
                Message = "Not found",
                Status = false
            };        
        }
        public async Task<LoginResponsemodel> CheckCustomer(LoginCustomerRequest loginCustomerRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginCustomerRequest.Email);
            return new LoginResponsemodel()
            {
                email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash)
            };
        }
    }
}