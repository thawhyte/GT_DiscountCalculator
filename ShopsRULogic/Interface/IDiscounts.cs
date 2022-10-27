using ShopsRUsModel.DTOs.DiscountsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Interface
{
    public interface IDiscounts
    {
        Task<List<GetDiscountsDTO>> GetAllDiscountsAsync();
        Task<GetDiscountsDTO> GetDiscountByTypeAsync(string type);
        Task AddNewDiscountTypeAsync(AddDiscountDTO input);
    }
}
