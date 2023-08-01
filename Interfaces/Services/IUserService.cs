using E_Commerce_2.Entities;
using E_Commerce_2.RequestModel;

namespace E_Commerce_2.Interfaces.Services
{
    public interface IUserService
    {
        User AddUser(UserRequestModel userRequestModel);
    }
}