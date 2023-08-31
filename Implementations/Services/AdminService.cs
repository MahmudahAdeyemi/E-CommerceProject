using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.Implementations.Repositories;
using E_Commerce_2.Interfaces.Repositories;
using E_Commerce_2.Interfaces.Services;
using E_Commerce_2.RequestModel;
using E_Commerce_2.ResponseModel;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_2.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAdminRepository _adminRepository;

        public AdminService(IMapper mapper, RoleManager<IdentityRole> roleManager, IAdminRepository adminRepository)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _adminRepository = adminRepository;
        }


        public async Task<BaseResponse> AddAdmin(UserRequestModel customerRequestModel)
        {
            var user = new User
            {
                Email = customerRequestModel.Email,
                FirstName = customerRequestModel.FirstName,
                LastName = customerRequestModel.LastName,
                PhoneNumber = customerRequestModel.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(customerRequestModel.Password)
            };
            string filename = null;
            if (customerRequestModel.ProfilePicture != null)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\ProfilePictures\\");
                bool basePathExist = Directory.Exists(basePath);
                if (!basePathExist)
                {
                    Directory.CreateDirectory(basePath);
                }
                var newfileName = Path.GetFileNameWithoutExtension(customerRequestModel.ProfilePicture.FileName);
                filename = Path.GetFileName(customerRequestModel.ProfilePicture.FileName);
                var filePath = Path.Combine(basePath, customerRequestModel.ProfilePicture.FileName);
                user.ProfilePicture = filename;
                if (!File.Exists(filePath))
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    customerRequestModel.ProfilePicture.CopyToAsync(stream);
                }
            }
            var role =await _roleManager.FindByNameAsync("Admin");
            var userRole = new IdentityUserRole<string>()
            {
                UserId = user.Id,
                RoleId = role.Id.ToString()
            };
            var admin = new Admin
            {
                User = user,
                UserId = user.Id
            };

           _adminRepository.CreateAdmin(admin);
            return new BaseResponse
            {
                Message = "Sucessfully done",
                Status = true
            };

        }
        public BaseResponse AdminLogin(LoginCustomerRequest loginCustomerRequest)
        {
            if (_adminRepository.GetAdminByEmail != null)
            {
                var user = _adminRepository.GetAdminByEmail(loginCustomerRequest.Email);
                if (BCrypt.Net.BCrypt.Verify(loginCustomerRequest.Password, user.User.PasswordHash))
                {
                    return new BaseResponse
                    {
                        Message = "Sucessfull done",
                        Status = true
                    };
                }
            }
            return new BaseResponse
            {
                Message = "Register before you login",
                Status = false
            };

        }
    }
}
