using AutoMapper;
using E_Commerce_2.Entities;
using E_Commerce_2.RequestModel;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_2.Implementations.Services
{
    public class CustomerService
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CustomerService(IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public void AddCustomer(CustomerRequestModel customerRequestModel)
        {
            var user = new User
            {
                Email = customerRequestModel.Email,
                FirstName = customerRequestModel.FirstName,
                LastName = customerRequestModel.LastName,
                PhoneNumber = customerRequestModel.PhoneNumber,
                PasswordHash = customerRequestModel.Password
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

                if (!File.Exists(filePath))
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    customerRequestModel.ProfilePicture.CopyToAsync(stream);
                }
            }
        }
    }
}