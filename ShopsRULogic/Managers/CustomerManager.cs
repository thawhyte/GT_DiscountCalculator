using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopsRULogic.Interface;
using ShopsRUsData.ApplicationDbContext;
using ShopsRUsData.Entities;
using ShopsRUsData.EntityFrameworkCore;
using ShopsRUsModel.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Managers
{
    public class CustomerManager : ICustomer
    {
        public readonly ShopsDbContext _db;
        private readonly IMapper _mapper;
        public CustomerManager(
            ShopsDbContext applicationDbContext, IMapper mapper)
        {
            this._db = applicationDbContext;
            this._mapper = mapper;
        }

        public async Task<List<CustomerGetDTO>> GetAllCustomersAsync()
        {
            List<CustomerGetDTO> resp = new();
            var output = await _db.customers.Where(x => !x.isDeleted).Select(x =>x ).ToListAsync();

            //Handling null
            if(output != null)
                resp = _mapper.Map<List<Customer>, List<CustomerGetDTO>>(output);
            return resp;
        }

        public async Task CreateCustomerAsync(CreateCustomerDTO input)
        {
            var data = _mapper.Map<CreateCustomerDTO, Customer>(input);

            if (!(new string[] { "male", "female", "others"}).Contains(data.Gender.ToLower()))
                throw new UserFriendlyException("Invalid gender submitted");
            if (data.BirthDate.Date < DateTime.UtcNow.Date.AddYears(-5))
                throw new UserFriendlyException("Birth date cannot lesser than 5 years");


            data.TenantID = 1;
            data.RegistrationDate = DateTime.UtcNow;
            data.isDeleted = false;
            await _db.customers.AddAsync(data);
            await SaveAsync();
        }


        public async Task<CustomerGetDTO> GetCustomerByIdAsync(int id)
        {
            CustomerGetDTO output = new();
            var result = await _db.customers.FindAsync(id);

            if (result != null)
                output = _mapper.Map<Customer, CustomerGetDTO>(result);
            else
                throw new UserFriendlyException("Customer Not found");
            return output;

        }

        public async Task<CustomerGetDTO> GetCustomerByNameAsync(string name)
        {
            CustomerGetDTO output = new();
            var results = await _db.customers.FirstOrDefaultAsync(x => !x.isDeleted && x.FirstName.ToLower().Contains(name.ToLower()) ||
                                 x.LastName.ToLower().Contains(name.ToLower()));

            if (results != null)
                output = _mapper.Map<Customer, CustomerGetDTO>(results);
            else
                throw new UserFriendlyException("Customer not found");
            return output;
        }

        //Saving to Database
        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }

    }
}
