using Core_Services.Abstract;
using Core_Services.Data;
using Core_Services.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

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

        public ActionResult ClearOperations()
        {
            _operationManager.DeleteAll();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            DollarValues.GetLastDollarValues();
            ViewBag.DollarValueBuy = DollarValues.PriceBuy;
            ViewBag.DollarValueSell = DollarValues.PriceSell;
            ViewBag.LastUpdate = DollarValues.Date;

            var targetOperation = _operationManager.GetById(id);

            var operation = new OperationViewModel 
            { 
                Id = id,
                Type = targetOperation.Type,
                Account = targetOperation.Account,
                Description = targetOperation.Description,
                AmountARS = targetOperation.AmountARS,
                AmountUSD = targetOperation.AmountUSD,
                Date = targetOperation.Date,
            };

            return View(operation);
        }

        public ActionResult Create()
        {
            DollarValues.GetLastDollarValues();
            ViewBag.DollarValueBuy = DollarValues.PriceBuy;
            ViewBag.DollarValueSell = DollarValues.PriceSell;
            ViewBag.LastUpdate = DollarValues.Date;

            return View();
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

                _operationManager.Add(operationEntity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            DollarValues.GetLastDollarValues();
            ViewBag.DollarValueBuy = DollarValues.PriceBuy;
            ViewBag.DollarValueSell = DollarValues.PriceSell;
            ViewBag.LastUpdate = DollarValues.Date;

            var targetOperation = _operationManager.GetById(id);

            var operation = new OperationViewModel
            {
                Id = id,
                Type = targetOperation.Type,
                Account = targetOperation.Account,
                Description = targetOperation.Description,
                AmountARS = targetOperation.AmountARS,
                AmountUSD = targetOperation.AmountUSD,
                Date = targetOperation.Date,
            };

            return View(operation);
        }

        [HttpPost]
        public ActionResult Edit(OperationEntity operation)
        {
            try
            {
                var operationEntity = new OperationEntity();

                operationEntity.Id = operation.Id;
                operationEntity.Type = operation.Type;
                operationEntity.Account = operation.Account;
                operationEntity.Description = operation.Description;
                operationEntity.AmountARS = operation.AmountARS;

                _operationManager.Update(operationEntity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            DollarValues.GetLastDollarValues();
            ViewBag.DollarValueBuy = DollarValues.PriceBuy;
            ViewBag.DollarValueSell = DollarValues.PriceSell;
            ViewBag.LastUpdate = DollarValues.Date;

            var targetOperation = _operationManager.GetById(id);

            var operation = new OperationViewModel
            {
                Id = id,
                Type = targetOperation.Type,
                Account = targetOperation.Account,
                Description = targetOperation.Description,
                AmountARS = targetOperation.AmountARS,
                AmountUSD = targetOperation.AmountUSD,
                Date = targetOperation.Date,
            };

            return View(operation);
        }

        [HttpPost]
        public ActionResult Delete(OperationEntity operation)
        {
            try
            {
                _operationManager.Delete(operation.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
