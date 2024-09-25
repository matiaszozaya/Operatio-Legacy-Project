using MVC_App.Entities;

namespace MVC_App.Abstract
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
