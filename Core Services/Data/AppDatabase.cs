using Core_Services.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Centvrio.Emoji;

namespace Core_Services.Data
{
    public static class AppDatabase
    {
        public static List<OperationEntity> Operations { get; set; }

        public static void InitializeDatabase()
        {
            Operations = new List<OperationEntity>
            {
                new OperationEntity
                {
                    Id = 1,
                    Type = "Necessity",
                    Description = $"{PlaceBuilding.House} Rent",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 2,
                    Type = "Necessity",
                    Description = $"{PlaceBuilding.Hospital} Health Care",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 3,
                    Type = "Necessity",
                    Description = $"{Computer.ElectricPlug} Electricity",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 4,
                    Type = "Necessity",
                    Description = $"{FoodPrepared.PoultryLeg} Food Expenses",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 5,
                    Type = "Necessity",
                    Description = $"{Computer.Laptop} Internet",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 6,
                    Type = "Debt",
                    Description = $"{Money.CreditCard} Visa Card | Credit Card",
                    Account = "Santander Rio",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 7,
                    Type = "Debt",
                    Description = $"{Money.CreditCard} American Express | Credit Card",
                    Account = "Santander Rio",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 8,
                    Type = "Debt",
                    Description = $"{Money.CreditCard} Visa & Naranja | Credit Cards",
                    Account = "Naranja X",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 9,
                    Type = "Debt",
                    Description = $"{Money.Dollar} Mercado Credito | Credit Line",
                    Account = "MercadoPago",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 10,
                    Type = "Debt",
                    Description = $"{Money.CreditCard} Mastercard | Credit Card",
                    Account = "Mi Carrefour",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 11,
                    Type = "Savings",
                    Description = $"{Money.MoneyWithWings} Savings",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 12,
                    Type = "Investments",
                    Description = $"{Money.MoneyWithWings} Investments",
                    Account = "Cash",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },
            };
        }

        public static void UpdateAmounts()
        {
            foreach (var operation in Operations)
            {
                //if(operation.AmountUSD > 0 && operation.AmountARS > 0)
                //{
                //    operation.AmountUSD = 0;
                //    operation.AmountARS = 0;
                //}

                if(operation.AmountUSD == null || operation.AmountUSD == 0)
                {
                    operation.AmountUSD = operation.AmountARS / DollarValues.PriceSell;
                }

                if (operation.AmountARS == null || operation.AmountARS == 0)
                {
                    operation.AmountARS = operation.AmountUSD * DollarValues.PriceSell;
                }
            }
        }

        public static void ClearOperations()
        {
            Operations.Clear();
        }
    }
}