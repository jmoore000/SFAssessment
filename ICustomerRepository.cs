namespace Assessment.Controllers
{
    public interface ICustomerRepository
    {
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void SaveCustomer(Customer customer);
    }
}