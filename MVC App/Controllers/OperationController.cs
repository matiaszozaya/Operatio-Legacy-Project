using Microsoft.AspNetCore.Mvc;
using MVC_App.Abstract;
using MVC_App.Data;
using MVC_App.Entities;

namespace MVC_App.Controllers
{
	public class OperationController : Controller
	{
		private readonly IOperationManager _operationManager;

		public OperationController(IOperationManager operationManager)
		{
			_operationManager = operationManager;
		}

		public ActionResult Index()
		{
			DollarValues.GetLastDollarValues();
			ViewBag.DollarValueBuy = DollarValues.PriceBuy;
			ViewBag.DollarValueSell = DollarValues.PriceSell;
			ViewBag.LastUpdate = DollarValues.Date;

			var lOperations = _operationManager.GetAll();

			ViewBag.Operations = lOperations;

			return View();
		}

		public PartialViewResult Create()
		{
			DollarValues.GetLastDollarValues();
			ViewBag.DollarValueBuy = DollarValues.PriceBuy;
			ViewBag.DollarValueSell = DollarValues.PriceSell;
			ViewBag.LastUpdate = DollarValues.Date;

			return PartialView();
		}

		[HttpPost]
		public ActionResult Create(OperationEntity operation)
		{
			try
			{
				var operationEntity = new OperationEntity();

				operationEntity.Type = operation.Type;
				operationEntity.Account = operation.Account;
				operationEntity.Description = operation.Description;
				operationEntity.AmountARS = operation.AmountARS;
				operationEntity.AmountUSD = operation.AmountUSD;

				_operationManager.Add(operationEntity);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return PartialView();
			}
		}

		public ActionResult EditView(int id)
		{
			DollarValues.GetLastDollarValues();
			ViewBag.DollarValueBuy = DollarValues.PriceBuy;
			ViewBag.DollarValueSell = DollarValues.PriceSell;
			ViewBag.LastUpdate = DollarValues.Date;

			var targetOperation = _operationManager.GetById(id);

			return Json(targetOperation);
		}

		[HttpPost]
		public ActionResult Edit([FromBody] OperationEntity operation)
		{
			try
			{
				var targetOperation = _operationManager.GetById(operation.Id);

				targetOperation.Type = operation.Type;
				targetOperation.Account = operation.Account;
				targetOperation.Description = operation.Description;
				targetOperation.AmountARS = operation.AmountARS;
				targetOperation.AmountUSD = operation.AmountUSD;
				targetOperation.Date = DateTime.Now;

				_operationManager.Update(targetOperation);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				return View(ex);
			}
		}

		public ActionResult Delete(int id)
		{
			try
			{
				_operationManager.Delete(id);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult ClearOperations()
		{
			AppDatabase.ClearOperations();

			return RedirectToAction(nameof(Index));
		}

		public ActionResult LoadOperations()
		{
			AppDatabase.InitializeDatabase();

			return RedirectToAction(nameof(Index));
		}
	}
}
