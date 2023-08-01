using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Services;
using E_Commerce_2.RequestModel;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_2.Services
{
    

    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

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
    }
}