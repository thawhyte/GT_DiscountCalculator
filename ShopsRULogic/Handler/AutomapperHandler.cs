using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopsRUsData.Entities;
using ShopsRUsModel.DTOs.CustomerDTOs;
using ShopsRUsModel.DTOs.DiscountsDTOs;
using ShopsRUsModel.DTOs.InvoiceDTOs;

namespace ShopsRULogic.Handler
{
    public class AutomapperHandler : Profile
    {
        public AutomapperHandler()
        {
            //Customer 
            //CreateMap<Customer, CustomerGetDTO>();
            CreateMap<Customer, CustomerGetDTO>()
                .ForMember(item => item.CustomerStatus,opt => opt.MapFrom(item => item.Active == true ? "Active" : "InActive"));

            CreateMap<CreateCustomerDTO,Customer>();
            CreateMap<Customer, CreateCustomerDTO> ();

            CreateMap<Customer, CustomerDetails>()
               .ForMember(item => item.CustomerName, opt => opt.MapFrom(item => item.FirstName + " " + item.LastName));


            //Discounts

            CreateMap<Discounts, GetDiscountsDTO>()
               .ForMember(item => item.IsDefault, opt => opt.MapFrom(item => item.IsDefault == true ? "Yes" : "No"));

            CreateMap<Discounts, AddDiscountDTO>();
            CreateMap<AddDiscountDTO, Discounts>();




        }
    }
}
