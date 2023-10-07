using BusinessLayer.Contracts.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities.Customer;

namespace FieldEdge.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetAllCustomers()
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
            return Ok(customers);
        }


        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> CreateCustomer(Customers customers)
        {
            CustomerResponse custResponse = new CustomerResponse();
            try
            {
                await _customerService.CreateCustomer(customers);
                if (1 == 1)
                {
                    custResponse.SuccessMessage = "Record Saved Successfully !";
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


        [HttpPost]
        [Route("Customer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            CustomerResponse custResponse = new CustomerResponse();
            try
            {
                int status = await _customerService.UpdateCustomer(id);
                if (1 == 1)
                {
                    custResponse.SuccessMessage = "Customer with Id =" + id + "updated successfully.";
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
