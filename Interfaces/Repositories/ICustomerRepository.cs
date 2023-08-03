using E_Commerce_2.Entities;

namespace E_Commerce_2.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer customer);
        Customer BlockCustomer(int id);
        Customer UpdateCustomer(Customer customer);
        Customer GetCustomerByEmail(string Email);
    }
}