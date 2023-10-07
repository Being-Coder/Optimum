using Dapper;
using RepositoryLayer.Common;
using RepositoryLayer.Contracts.Customer;
using RepositoryLayer.Entities.Customer;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos.Customer
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly DapperContext _context;
        public CustomerRepo(DapperContext context) 
        { 
            _context = context;
        }

        public async Task<int> CreateCustomer(Customers customers)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var parameters = new DynamicParameters();
            int rowsAffected;
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                rowsAffected = await connection.ExecuteAsync
                    ("DeleteCustomerById", parameters, commandType: CommandType.StoredProcedure);
            }
            return rowsAffected;
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            IEnumerable<Customers> customers = new List<Customers>();

            using(var connection = _context.CreateConnection())
            {
                customers = await connection.QueryAsync<Customers>("GetAllCustomers", commandType:CommandType.StoredProcedure);
            }
            return customers;
        }

        public async Task<Customers> GetCustomerById(int id)
        {
            Customers customer = new Customers();

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                customer = await connection.QueryFirstOrDefaultAsync<Customers>
                    ("GetCustomerById", parameters, commandType: CommandType.StoredProcedure);
            }
            return customer;
        }

        public Task<int> UpdateCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
