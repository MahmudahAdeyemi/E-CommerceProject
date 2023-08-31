using E_Commerce_2.RequestModel;
using E_Commerce_2.ResponseModel;

namespace E_Commerce_2.Interfaces.Services
{
    public interface IAdminService
    {
        Task<BaseResponse> AddAdmin(UserRequestModel customerRequestModel);
        BaseResponse AdminLogin(LoginCustomerRequest loginCustomerRequest);
    }
}