using E_Commerce_2.Entities;
using E_Commerce_2.RequestModel;
using E_Commerce_2.ResponseModel;

namespace E_Commerce_2.Interfaces.Services
{
    public interface IUserService
    {
        User AddUser(UserRequestModel userRequestModel);
        BaseResponse UserLogin (LoginCustomerRequest loginCustomerRequest);
        Task<LoginResponsemodel> CheckCustomer(LoginCustomerRequest loginCustomerRequest);
    }
}