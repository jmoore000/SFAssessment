using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        [HttpPost]
        public void SaveCustomer([FromBody] Customer customer)
        {
            _customerRepository.SaveCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }
    }
}
