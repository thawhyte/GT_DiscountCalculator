using ShopsRUsData.Entities;
using ShopsRUsData.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsData.ApplicationDbContext
{
    public static class SeedHelper
    {
        public static async Task InitializeData(ShopsDbContext context)
        {
            //1. check if customers contain data
            if (!context.customers.Any())
            {
                context.customers.AddRange(new List<Customer>   
                {
                    new Customer
                    {
                        FirstName = "Taiwo",
                        LastName = "Abioye",
                        BirthDate = DateTime.Now.AddYears(-20),
                        Gender = "Male",
                        //Gender = GenderEnum.Male,
                        Address = "Lagos Street",
                        PhoneNo = "08146663777",
                        Email = "taiwo.abioye@gmail.com",
                        Active = true,
                        CompanyName= "Ajitewa Makeover",
                        IsCustomerAffiliate = true,
                        IsCustomerAnEmployee = false,
                        isDeleted = false,
                        RegistrationDate = DateTime.Now.AddYears(-1),
                        TenantID =1
                    },
                    new Customer
                    {
                        FirstName = "Keneth",
                        LastName = "Samson",
                        BirthDate = DateTime.Now.AddYears(-50),
                        Gender = "Male",
                        //Gender = GenderEnum.Male,
                        Address = "Ibadan",
                        PhoneNo = "77777777",
                        Email = "kenethJames@gmail.com",
                        Active = true,
                        CompanyName= "Tinted Glouse",
                        IsCustomerAffiliate = false,
                        IsCustomerAnEmployee = true,
                        isDeleted = false,
                        RegistrationDate = DateTime.Now.AddYears(-3),
                        TenantID =1
                    },
                    new Customer
                    {
                        FirstName = "Christian",
                        LastName = "Ronaldo",
                        BirthDate = DateTime.Now.AddYears(-70),
                        Gender = "Male",
                        //Gender = GenderEnum.Male,
                        Address = "Manchester",
                        PhoneNo = "+1243430343",
                        Email = "c.ronaldo@manchester.com",
                        Active = true,
                        CompanyName= "Ajitewa Makeover",
                        IsCustomerAffiliate = false,
                        IsCustomerAnEmployee = true,
                        isDeleted = false,
                        RegistrationDate = DateTime.Now.AddYears(-2),
                        TenantID =1
                    },
                    new Customer
                    {
                        FirstName = "Elon",
                        LastName = "Musk",
                        BirthDate = DateTime.Now.AddYears(-45),
                        Gender = "Male",
                        //Gender = GenderEnum.Male,
                        Address = "Silicon Valley",
                        PhoneNo = "478234433",
                        Email = "elon.musk@tesla.com",
                        Active = true,
                        CompanyName= "Tesla",
                        IsCustomerAffiliate = false,
                        IsCustomerAnEmployee = false,
                        isDeleted = false,
                        RegistrationDate = DateTime.Now.AddYears(-3),
                        TenantID =1
                    }
                });
                
                await context.SaveChangesAsync();
            }

            //Asset items
            if (!context.assetItems.Any())
            {
                context.assetItems.AddRange(new List<AssetItems>
                {
                    new AssetItems
                    {
                        ItemCode = "ITEM001",
                         ItemName = "Laptop",
                         ItemDescription = "MacBook M1",
                         AssetType= "Computer",
                          MarketIntelligencePrice = 72193,
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM002",
                         ItemName = "Car",
                         ItemDescription = "Benz",
                         AssetType= "Motor-Vehicle",
                          MarketIntelligencePrice = 558933932
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM003",
                         ItemName = "Table",
                         ItemDescription = "Table and Chair",
                         AssetType = "Furniture",
                          MarketIntelligencePrice = 8583930
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM004",
                         ItemName = "Air condition",
                         ItemDescription = "2 HP AC",
                         AssetType = "Electronics",
                          MarketIntelligencePrice = 959593
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM005",
                         ItemName = "Gucci",
                         ItemDescription = "Gucci Jacket",
                         AssetType ="Clothings",
                          MarketIntelligencePrice = 432244
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM006",
                         ItemName = "MEAT",
                         ItemDescription = "Meat / Protein",
                         AssetType ="Groceries",
                          MarketIntelligencePrice = 57833
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM007",
                         ItemName = "Pepper",
                         ItemDescription = "Tomatoes an Rodo",
                         AssetType ="Groceries",
                          MarketIntelligencePrice = 4738
                    },
                    new AssetItems
                    {
                        ItemCode = "ITEM008",
                         ItemName = "Spices",
                         ItemDescription = "Chilli Powder",
                         AssetType ="Groceries",
                          MarketIntelligencePrice = 6848
                    },
                });

                await context.SaveChangesAsync();
            }

            //Discounts
            if (!context.Discounts.Any())
            {
                context.Discounts.AddRange(new List<Discounts>
                {
                    new Discounts
                    {
                         Percentage  = 10,
                          DiscountType = "Affiliate",
                           IsDefault = false,
                            isDeleted = false,
                             Created_By = "System",
                                Create_date = DateTime.Now.AddYears(-1).Date,
                    },
                    new Discounts
                    {
                         Percentage  = 30,
                          DiscountType = "Employee",
                           IsDefault = false,
                            isDeleted = false,
                             Created_By = "System",
                                Create_date = DateTime.Now.AddYears(-1).Date,
                    },
                    new Discounts
                    {
                         Percentage  = 5,
                          DiscountType = "Over2years",
                           IsDefault = false,
                            isDeleted = false,
                             Created_By = "System",
                                Create_date = DateTime.Now.AddYears(-1).Date,
                                 
                    },
                    new Discounts
                    {
                        // (45 / 990) x 100 = 4.55%
                         Percentage  = 4.55M, // $100 on the bill, there would be a $5 discount (e.g. for $990, you get $45 as a discount)
                          DiscountType = "HundredDollar",
                           IsDefault = true,
                            isDeleted = false,
                              Created_By = "System",
                                Create_date = DateTime.Now.AddYears(-1).Date,
                    },
                    new Discounts
                    {
                         Percentage  = 0,
                          DiscountType = "Groceries",
                           IsDefault = false,
                            isDeleted = false,
                              Created_By = "System",
                                Create_date = DateTime.Now.AddYears(-1).Date,
                    },
                });

                await context.SaveChangesAsync();
            }


            //Invoice

            if (!context.invoices.Any())
            {
                context.invoices.AddRange(new List<Invoice>
                {
                    new Invoice
                    {
                         Initiator ="System",
                          InvoiceNo = 3425,
                           Quantity = 1,
                            IsDeleted = false,
                             ReferenceNo = "INV/27/10/2022/3425",
                              ClientID = 4,
                               DiscountId = null,
                                ItemID = "ITEM007",
                                 TransactionDate = DateTime.UtcNow,
                                  SubtotalAmount = 4738,
                                   TotalBalanceAmount = 4738,
                                    TotalBalanceInWords = "four thousand seven hundred  thirty eight dollar only",
                                     TotalItemAmount = 4738,
                                      Currency ="Dollar"
                    },
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
