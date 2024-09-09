using RestWithController.Models;

namespace RestWithController.Repositories
{
    public interface IStoreListRepository
    {
        void Add(Store s);
        void Delete(int id);
        List<Store> GetAllStores();
        Store? GetById(int id);
        List<Store> GetStoresByLocation(string location);
        void UpdateStore(int id, Store s);
    }
}