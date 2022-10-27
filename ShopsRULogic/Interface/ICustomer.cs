using ShopsRUsModel.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Interface
{
    public interface ICustomer
    {
        Task<List<CustomerGetDTO>> GetAllCustomersAsync();
        Task CreateCustomerAsync(CreateCustomerDTO input);
        //Task CreateCustomerBulkAsync(List<CreateCustomerDTO> input);
        Task<CustomerGetDTO> GetCustomerByIdAsync(int id);
        Task<CustomerGetDTO> GetCustomerByNameAsync(string name);

    }
}
