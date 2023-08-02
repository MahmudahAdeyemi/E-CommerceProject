using E_Commerce_2.Context;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Repositories;

namespace E_Commerce_2.Implementations.Repositories
{
    
    public class AdminRepository : IAdminRepository
    {
        private readonly E_commerceContext _e_commerceContext;
        public AdminRepository(E_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Admin CreateAdmin(Admin admin)
        {
            _e_commerceContext.Add(admin);
            return (admin);
        }
        public Admin UpdateAdmin(Admin admin)
        {
            _e_commerceContext.Admins.Update(admin);
            return (admin);
        }
        public void ChangePassword(Admin admin)
        {
            _e_commerceContext.Update(admin);
        }
        public Admin GetAdminById(int id)
        {
            return (_e_commerceContext.Admins.Single(x => x.Id == id));

        }
    }
}