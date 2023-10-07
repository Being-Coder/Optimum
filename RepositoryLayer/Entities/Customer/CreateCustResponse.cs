using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities.Customer
{
    public class CustomerResponse
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public CustomerResponse(string successMessage, string errorMessage)
        {
            SuccessMessage = successMessage;
            ErrorMessage = errorMessage;
        }

        public CustomerResponse() { }

    }
}
