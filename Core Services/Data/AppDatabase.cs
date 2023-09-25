using Core_Services.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Description = "Rent",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 2,
                    Type = "Necessity",
                    Description = "Health Care",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 3,
                    Type = "Necessity",
                    Description = "Electricity",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 4,
                    Type = "Necessity",
                    Description = "Food Expenses",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 5,
                    Type = "Necessity",
                    Description = "Internet",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 6,
                    Type = "Debt",
                    Description = "Visa Card | Credit Card",
                    Account = "Santander Rio",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 7,
                    Type = "Debt",
                    Description = "American Express | Credit Card",
                    Account = "Santander Rio",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 8,
                    Type = "Debt",
                    Description = "Visa & Naranja | Credit Cards",
                    Account = "Naranja X",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 9,
                    Type = "Debt",
                    Description = "Mercado Credito | Credit Line",
                    Account = "MercadoPago",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 10,
                    Type = "Debt",
                    Description = "Mastercard | Credit Card",
                    Account = "Mi Carrefour",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 11,
                    Type = "Savings",
                    Description = "",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },

                new OperationEntity
                {
                    Id = 12,
                    Type = "Investments",
                    Description = "",
                    Account = "",
                    AmountARS = (decimal?)0,
                    AmountUSD = 0,
                    Date = DateTime.Now,
                },
            };
        }

        public static void UpdateAmountUSD()
        {
            foreach (var operation in Operations)
            {
                operation.AmountUSD = operation.AmountARS / DollarValues.PriceSell;
            }
        }

        public static void ClearOperations()
        {
            Operations.Clear();
        }
    }
}
