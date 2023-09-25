using Core_Services.Abstract;
using Core_Services.Data;
using Core_Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Services.Concrete
{
    public class OperationManager : IOperationManager
    {
        public void Add(OperationEntity operation)
        {
            var operationEntity = new OperationEntity();

            operationEntity.Id = GetNewId();
            operationEntity.Type = operation.Type;
            operationEntity.Account = operation.Account;
            operationEntity.Description = operation.Description;
            operationEntity.AmountARS = operation.AmountARS;
            operationEntity.AmountUSD = operation.AmountARS / DollarValues.PriceSell;
            operationEntity.Date = DateTime.Now;

            AppDatabase.Operations.Add(operationEntity);
        }

        public bool Update(OperationEntity operation)
        {
            var updated = false;
            var filtered = AppDatabase.Operations.Find(x => x.Id == operation.Id);
            if (filtered != null)
            {
                filtered.Type = operation.Type;
                filtered.Account = operation.Account;
                filtered.Description = operation.Description;
                filtered.AmountARS = operation.AmountARS;
                filtered.AmountUSD = operation.AmountARS / DollarValues.PriceSell;

                updated = true;
            }

            return updated;
        }

        public bool Delete(int id)
        {
            return AppDatabase.Operations.RemoveAll(x => x.Id == id) > 0;
        }

        public bool DeleteAll()
        {
            try
            {
                AppDatabase.Operations.RemoveAll(x => x.Id > 0);
                return true;
            }
            catch 
            { 
                return false;
            } 
        }

        public int GetNewId()
        {
            if(AppDatabase.Operations.Count > 0)
            {
                return AppDatabase.Operations.Max(operation => operation.Id) + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<OperationEntity> GetAll()
        {
            return AppDatabase.Operations.ToList();
        }

        public OperationEntity GetById(int id)
        {  
            return AppDatabase.Operations.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}