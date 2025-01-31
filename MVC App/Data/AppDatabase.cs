using Centvrio.Emoji;
using MVC_App.Entities;

namespace MVC_App.Data
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
					Description = $"{Computer.ElectricPlug} Electricity",
					Account = "Cash",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 3,
					Type = "Debt",
					Description = $"{Money.CreditCard} Visa Card | Credit Card",
					Account = "Santander Rio",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 4,
					Type = "Debt",
					Description = $"{Money.CreditCard} American Express | Credit Card",
					Account = "Santander Rio",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 5,
					Type = "Debt",
					Description = $"{Money.CreditCard} Visa & Naranja | Credit Cards",
					Account = "Naranja X",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 6,
					Type = "Debt",
					Description = $"{Money.Dollar} Mercado Credito | Credit Line",
					Account = "MercadoPago",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 7,
					Type = "Debt",
					Description = $"{Money.CreditCard} Mastercard | Credit Card",
					Account = "Mi Carrefour",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 8,
					Type = "Taxes",
					Description = $"{PersonFantasy.Supervillain} Taxes",
					Account = "Cash",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 9,
					Type = "Savings",
					Description = $"{Money.MoneyWithWings} Savings",
					Account = "Cash",
					AmountARS = (decimal?)0,
					AmountUSD = 0,
					Date = DateTime.Now,
				},

				new OperationEntity
				{
					Id = 10,
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

				if (operation.AmountUSD == null || operation.AmountUSD == 0)
				{
					operation.AmountUSD = operation.AmountARS / DollarValues.PriceBuy;
				}

				if (operation.AmountARS == null || operation.AmountARS == 0)
				{
					operation.AmountARS = operation.AmountUSD * DollarValues.PriceBuy;
				}
			}
		}

		public static void ClearOperations()
		{
			Operations.Clear();
		}
	}
}