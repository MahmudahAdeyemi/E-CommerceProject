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


    public class CustomerService : ICustomerService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICartRepository cartRepository, IMapper mapper, RoleManager<IdentityRole> roleManager, ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _roleManager = roleManager;
            _customerRepository = customerRepository;
        }

        public BaseResponse AddCustomer(UserRequestModel customerRequestModel)
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

                if (!File.Exists(filePath))
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    customerRequestModel.ProfilePicture.CopyToAsync(stream);
                }
            }
            var role = _roleManager.FindByNameAsync("Customer");
            var userRole = new IdentityUserRole<string>()
            {
                UserId = user.Id,
                RoleId = role.Id.ToString()
            };
            var cart = new Cart();
            _cartRepository.AddCart(cart);

            var customer = new Customer
            {
                User = user,
                UserId = int.Parse(user.Id),
                CartId = cart.Id
            };

            _customerRepository.AddCustomer(customer);
            return new BaseResponse
            {
                Message = "Sucessfully done",
                Status = true
            };

        }
        public BaseResponse CustomerLogin(LoginCustomerRequest loginCustomerRequest)
        {
            if (_customerRepository.GetCustomerByEmail(loginCustomerRequest.Email) != null)
            {
                var user = _customerRepository.GetCustomerByEmail(loginCustomerRequest.Email);
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