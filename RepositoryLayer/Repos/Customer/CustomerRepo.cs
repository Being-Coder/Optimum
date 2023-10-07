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
            int newId;
            var parameters = new DynamicParameters();
            parameters.Add("Firstname", customers.Firstname, DbType.String);
            parameters.Add("Gender", customers.Gender, DbType.String);
            parameters.Add("Lastname", customers.Lastname, DbType.String);
            parameters.Add("Email", customers.Email, DbType.String);
            parameters.Add("Country_Code", customers.Country_Code, DbType.String);
            parameters.Add("Country_Name", customers.Country_Name, DbType.String);
            parameters.Add("Balance", customers.Balance, DbType.Int32);
            parameters.Add("Phone_Number", customers.Phone_Number, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                newId = await connection.QuerySingleAsync<int>("AddNewCustomer", parameters, commandType:CommandType.StoredProcedure);
            }
            return newId;
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

        public async Task<int> UpdateCustomer(Customers customer)
        {
            int affectedRows;
            var parameters = new DynamicParameters();
            parameters.Add("Id", customer.Id, DbType.Int32);
            parameters.Add("Firstname", customer.Firstname, DbType.String);
            parameters.Add("Gender", customer.Gender, DbType.String);
            parameters.Add("Lastname", customer.Lastname, DbType.String);
            parameters.Add("Email", customer.Email, DbType.String);
            parameters.Add("Country_Code", customer.Country_Code, DbType.String);
            parameters.Add("Country_Name", customer.Country_Name, DbType.String);
            parameters.Add("Balance", customer.Balance, DbType.Int32);
            parameters.Add("Phone_Number", customer.Phone_Number, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                affectedRows = await connection.ExecuteAsync("UpdateCustomer", parameters, commandType: CommandType.StoredProcedure);
            }
            return affectedRows;
        }
    }
}
