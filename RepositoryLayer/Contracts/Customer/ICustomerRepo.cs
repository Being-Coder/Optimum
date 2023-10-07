using RepositoryLayer.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts.Customer
{
    public interface ICustomerRepo
    {
        Task<int> CreateCustomer(Customers customers);
        Task<int> DeleteCustomer(int id);
        Task<IEnumerable<Customers>> GetAllCustomers();
        Task<Customers> GetCustomerById(int id);
        Task<int> UpdateCustomer(Customers customer);
    }
}
