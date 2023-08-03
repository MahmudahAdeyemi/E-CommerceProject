using E_Commerce_2.Context;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Repositories;

namespace E_Commerce_2.Implementations.Repositories
{
    

    public class CustomerRepository : ICustomerRepository
    {
        private readonly E_commerceContext _e_commerceContext;
        public CustomerRepository(E_commerceContext e_CommerceContext)
        {
            _e_commerceContext = e_CommerceContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _e_commerceContext.Add(customer);
            _e_commerceContext.SaveChanges();
            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            _e_commerceContext.Update(customer);
            _e_commerceContext.SaveChanges();
            return customer;
        }
        public Customer BlockCustomer(int id)
        {
            var customer = _e_commerceContext.Customers.Single(x => x.Id == id);
            _e_commerceContext.Remove(customer);
            _e_commerceContext.SaveChanges();
            return customer;
        }
        public Customer GetCustomerByEmail(string Email)
        {
            var customer = _e_commerceContext.Customers.SingleOrDefault(x =>  x.User.Email == Email );
            return customer;
        }
    }
}