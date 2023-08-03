using E_Commerce_2.RequestModel;
using E_Commerce_2.ResponseModel;

namespace E_Commerce_2.Interfaces.Services
{
    public interface ICustomerService
    {
        BaseResponse AddCustomer(CustomerRequestModel customerRequestModel);
        BaseResponse CustomerLogin(LoginCustomerRequest loginCustomerRequest);
    }
}