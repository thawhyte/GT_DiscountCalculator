using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopsRULogic.Interface;
using ShopsRUsData.Entities;
using ShopsRUsData.EntityFrameworkCore;
using ShopsRUsModel.DTOs.DiscountsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Managers
{
    public class DiscountsManager : IDiscounts
    {
        public readonly ShopsDbContext _db;
        private readonly IMapper _mapper;

        public DiscountsManager(ShopsDbContext shopsDbContext, IMapper mapper)
        {
            this._db = shopsDbContext;
            this._mapper = mapper;
        }


        public async Task<List<GetDiscountsDTO>> GetAllDiscountsAsync()
        {
            List<GetDiscountsDTO> dataList = new();
            var output = await _db.Discounts.ToListAsync();
            //Handling null
            if (output.Count() != 0)
                dataList = _mapper.Map<List<Discounts>, List<GetDiscountsDTO>>(output);
            return dataList;
        }

        public async Task<GetDiscountsDTO> GetDiscountByTypeAsync(string type)
        {
            GetDiscountsDTO dataList = new();
            var output = await _db.Discounts.FirstOrDefaultAsync(x => x.DiscountType.ToLower().Contains(type.ToLower()));
            if (output != null)
                dataList = _mapper.Map<Discounts, GetDiscountsDTO>(output);
            else
                throw new UserFriendlyException("Discount type not found! ");

            return dataList;
        }

        public async Task AddNewDiscountTypeAsync(AddDiscountDTO input)
        {
            var checkData = await _db.Discounts.FirstOrDefaultAsync(x => x.DiscountType.ToLower().Trim() == input.DiscountType.ToLower().Trim());
            if (checkData != null)
                throw new UserFriendlyException("Discount type already exists");

            var data = _mapper.Map<AddDiscountDTO, Discounts>(input);
            data.Created_By = "Current_User";
            data.Create_date = DateTime.UtcNow.Date;
            data.isDeleted = false;
            data.IsDefault = false;

            await _db.Discounts.AddAsync(data);
            await SaveAsync();
        }


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
