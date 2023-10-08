using BusinessLayer.Contracts.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities.Customer;

namespace FieldEdge.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }


        [HttpGet]
        [Route("Customers")]
        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            IEnumerable<Customers> customers = new List<Customers>();
            try
            {
                customers = await _customerService.GetAllCustomers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return customers;
        }


        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> CreateCustomer(Customers customers)
        {
            CustomerResponse custResponse = new CustomerResponse();
            try
            {
                int id = await _customerService.CreateCustomer(customers);
                if (id > 0)
                {
                    custResponse.SuccessMessage = "Record created with Id = "+ id +" Successfully !";
                    custResponse.Customers = GetAllCustomers();
                }
            }
            catch (Exception ex)
            {
                custResponse.ErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return Ok(custResponse);
        }


        [HttpGet]
        [Route("Customer/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            Customers customer = new Customers();
            try
            {
                customer = await _customerService.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return Ok(customer);
        }


        [HttpPut]
        [Route("Customer")]
        public async Task<IActionResult> UpdateCustomer(Customers customer)
        {
            CustomerResponse custResponse = new CustomerResponse();
            try
            {
                int status = await _customerService.UpdateCustomer(customer);
                if (status == 1)
                {
                    custResponse.SuccessMessage = "Customer with Id =" + customer.Id + "updated successfully.";
                    custResponse.Customers = GetAllCustomers();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return Ok(custResponse);
        }


        [HttpDelete]
        [Route("Customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            CustomerResponse custResponse = new CustomerResponse();
            try
            {
                int Success  = await _customerService.DeleteCustomer(id);
                if(Success == 1)
                {
                    custResponse.SuccessMessage = "Deleted Successfully.";
                    custResponse.Customers = GetAllCustomers();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return Ok(custResponse);
        }

    }
}
