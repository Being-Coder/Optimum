using BusinessLayer.Contracts.Customer;
using RepositoryLayer.Contracts.Customer;
using RepositoryLayer.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<int> CreateCustomer(Customers customers)
        {
            return await _customerRepo.CreateCustomer(customers);
        }

        public async Task<int> DeleteCustomer(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            return await _customerRepo.GetAllCustomers();
        }

        public async Task<Customers> GetCustomerById(int id)
        {
            return await _customerRepo.GetCustomerById(id);
        }

        public async Task<int> UpdateCustomer(Customers customer)
        {
            return await _customerRepo.UpdateCustomer(customer);
        }
    }
}
