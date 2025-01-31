using Microsoft.AspNetCore.Mvc;
using MVC_App.Data;

namespace MVC_App.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			DollarValues.GetLastDollarValues();
			ViewBag.DollarValueBuy = DollarValues.PriceBuy;
			ViewBag.DollarValueSell = DollarValues.PriceSell;
			ViewBag.LastUpdate = DollarValues.Date;

			return View();
		}
	}
}