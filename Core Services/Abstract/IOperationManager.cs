using Core_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Services.Abstract
{
    public interface IOperationManager
    {
        OperationEntity GetById(int id);
        List<OperationEntity> GetAll();
        void Add(OperationEntity account);
        bool Update(OperationEntity account);
        bool Delete(int id);
        bool DeleteAll();
        int GetNewId();
    }
}
