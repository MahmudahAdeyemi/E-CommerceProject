using E_Commerce_2.Entities;

namespace E_Commerce_2.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        void ChangePassword(Admin admin);
        Admin CreateAdmin(Admin admin);
        Admin GetAdminById(int id);
        Admin UpdateAdmin(Admin admin);
        Admin GetAdminByEmail(string Email);
    }

}