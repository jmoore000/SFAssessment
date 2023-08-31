using Assessment.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Assessment
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext _dbContext; private readonly DbSet<Customer> _customers;

        public CustomerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _customers = dbContext.Set<Customer>();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.Find(id);
        }

        public void SaveCustomer(Customer customer)
        {
            _customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customers.Find(id);
            if (customer != null)
            {
                _customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }
    }
}