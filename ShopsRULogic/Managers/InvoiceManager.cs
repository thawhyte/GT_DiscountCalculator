using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopsRULogic.Handler;
using ShopsRULogic.Interface;
using ShopsRUsData.Entities;
using ShopsRUsData.EntityFrameworkCore;
using ShopsRUsModel.DTOs;
using ShopsRUsModel.DTOs.InvoiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Managers
{
    public class InvoiceManager : IInvoice
    {
        public readonly ShopsDbContext _db;
        private readonly IMapper _mapper;
        private readonly AmountToWords _amountToWords;
        public InvoiceManager(
            ShopsDbContext shopsDbContext, 
            IMapper mapper,
            AmountToWords amountToWords

            )
        {
            this._db = shopsDbContext;
            this._mapper = mapper;
            this._amountToWords = amountToWords;
               
        }


        public async Task<GetTotalInvoiceDetailsDTO> GetInvoiceDetailsAsync(InvoiceRequest input)
        {
            GetTotalInvoiceDetailsDTO outputData = new();
            Random rnd = new Random();
            int number = rnd.Next(1, 10000);
            Boolean decideDiscount = false;
            int DiscountID = 0;

            //first is to check for valid customer ID(believed to be a drop down from the interface)
            var customerDetails = await _db.customers.FindAsync(input.CustomerId);
            if(customerDetails == null)
                throw new UserFriendlyException("Customer Not Found");
            if (input.Quantity < 1)
                throw new UserFriendlyException("Item Quantity cannot be 0");

            //Validating itemcode
            var itemData = await _db.assetItems.FirstOrDefaultAsync(x => x.ItemCode.ToLower() == input.ItemCode.ToLower());
            if (itemData == null)
                throw new UserFriendlyException("Item Not Found");

            //Mapping of valid customer DATA
            outputData.customerDetails = _mapper.Map<Customer, CustomerDetails>(customerDetails);

            

            if (customerDetails.IsCustomerAffiliate && itemData.AssetType.ToLower() != "groceries")
            {
                DiscountID = 1;
                outputData.Disount = await DiscountGeneratorAsync(DiscountID); 
                decideDiscount = true;   //1 is for affiliate
            }
            else if (customerDetails.IsCustomerAnEmployee && itemData.AssetType.ToLower() != "groceries")
            {
                DiscountID = 2;
                outputData.Disount = await DiscountGeneratorAsync(DiscountID); 
                decideDiscount = true;
            }
            else if (customerDetails.RegistrationDate.Year - DateTime.UtcNow.Year > 2 && itemData.AssetType.ToLower() != "groceries")
            {
                DiscountID = 3;
                outputData.Disount = await DiscountGeneratorAsync(DiscountID); 
                decideDiscount = true;
            }
            //Hundred dollar
            else if (itemData.MarketIntelligencePrice % 100 != 0 && itemData.AssetType.ToLower() != "groceries")
            {
                DiscountID = 4;
                outputData.Disount = await DiscountGeneratorAsync(DiscountID) * (itemData.MarketIntelligencePrice % 100); 
                decideDiscount = false;
            }
            //Handling if client is both employed and affiliate
            else if(customerDetails.IsCustomerAnEmployee && customerDetails.IsCustomerAnEmployee 
                    && itemData.AssetType.ToLower() != "groceries")
            {
                //Implementation not provided
            }




            //Item Details
            outputData.itemDetails.ItemName = itemData.ItemName;
            outputData.itemDetails.Quantity = input.Quantity;
            outputData.itemDetails.UnitPrice = itemData.MarketIntelligencePrice;
            outputData.itemDetails.Total = input.Quantity * itemData.MarketIntelligencePrice;

            //string.Format("{0:N2}", records.Proceeds);

            outputData.DiscountType = decideDiscount == true ? "Percentage" : "Currency Value";
            outputData.SubTotalAmount = outputData.itemDetails.Total;
            outputData.TotalBalanceAmount = decideDiscount == true ? (outputData.Disount == 0 ? outputData.SubTotalAmount : (outputData.SubTotalAmount * outputData.Disount) / 100)  : outputData.SubTotalAmount - outputData.Disount;
            outputData.AmountInWords = _amountToWords.NumberToWords((double)outputData.TotalBalanceAmount);
            outputData.TransactionDate = DateTime.UtcNow.Date;
            outputData.InvoiceNo = number;
            outputData.ReferenceNo = "INV/" + DateTime.Now.ToString("dd/MM/yyyy") +"/"+ number;


            //Saving the invoice transaction in a table
            await SaveInvoiceDataAsync(outputData, DiscountID, input);
            
            //Output data
            return outputData;

        }


        public async Task SaveInvoiceDataAsync(GetTotalInvoiceDetailsDTO input, int discountID, InvoiceRequest req)
        {
            Invoice iv = new();
            iv.TotalItemAmount = input.TotalBalanceAmount;
            iv.ClientID = req.CustomerId;
            iv.DiscountId = discountID;
            iv.Initiator = "SwaggerUI"; //getUser();
            iv.Currency = "Dollar";
            iv.InvoiceNo = input.InvoiceNo;
            iv.IsDeleted = false;
            iv.ItemID = req.ItemCode;
            iv.Quantity = input.itemDetails.Quantity;
            iv.ReferenceNo = input.ReferenceNo;
            iv.SubtotalAmount = input.SubTotalAmount;
            iv.TotalBalanceAmount = input.TotalBalanceAmount;
            iv.TotalItemAmount = input.itemDetails.Total;
            iv.TotalBalanceInWords = input.AmountInWords;
            iv.TransactionDate = DateTime.UtcNow;
            await _db.invoices.AddAsync(iv);
            await Save();
        }

        
        public async Task<decimal> DiscountGeneratorAsync(int id)
        {
            var data = await _db.Discounts.FindAsync(id);
            return data.Percentage;
        }

        


        //public async Task<GetTotalInvoiceDetailsDTO> GetInvoiceDetailsAsync(InvoiceRequest input)
        //{
        //    GetTotalInvoiceDetailsDTO outputData = new();
        //    //first is to check for valid customer ID(believed to be a drop down from the interface)
        //    var customerDetails = await _db.customers.FindAsync(input.CustomerId);
        //    if (customerDetails == null)
        //        throw new UserFriendlyException("Customer Not Found");

        //    //Validating itemcode
        //    var itemData = await _db.assetItems.Where(x => input.ItemDetails.All(x2 => x.ItemCode.Contains(x2.ItemCode))).Select(x => x).ToListAsync();
        //    if (itemData.Count() == 0)
        //        throw new UserFriendlyException("Item(s) Not Found");

        //    decimal discountAmount = 0;

        //    if (customerDetails.IsCustomerAffiliate && !itemData.All(p => p.ItemName.Contains("Groceries")))
        //        discountAmount = await DiscountGeneratorAsync(1); //1 is for affiliate
        //    else if (customerDetails.IsCustomerAnEmployee && !itemData.All(p => p.ItemName.Contains("Groceries")))
        //        discountAmount = await DiscountGeneratorAsync(2);
        //    else if (customerDetails.RegistrationDate.Year - DateTime.UtcNow.Year > 2)
        //        discountAmount = await DiscountGeneratorAsync(3);
        //    else if ()

        //        //Mapping of valid customer DATA
        //        outputData.customerDetails = _mapper.Map<Customer, CustomerDetails>(customerDetails);









        //    return outputData;


        //}



        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

    }

}
