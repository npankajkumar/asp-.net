using RestWithController.Models;
using System.Collections.Generic;
namespace RestWithController.Repositories
{
    public class StoreListRepository : IStoreListRepository
    {
        public List<Store> list = new List<Store>();
        public void Add(Store s)
        {
            list.Add(s);
        }
        public List<Store> GetAllStores()
        {
            return list;
        }
        public List<Store> GetStoresByLocation(string location)
        {
            //LINQ - Language intergrated query
            return (from s in list
                    where s.Location == location
                    orderby s.Id
                    select s).ToList();

        }
        public Store? GetById(int id)
        {
            /*  return (from s in list
                      where s.Id == id
                      select s).FirstOrDefault() ;*/
            return list.Find(s => s.Id == id);//extension method
        }
        public void Delete(int id)
        {
            var find = list.Where(l => l.Id == id).FirstOrDefault();
            list.Remove(find);
        }
        public void UpdateStore(int id, Store s)
        {
            var find = list.Where(l => l.Id == id).FirstOrDefault();
            if (find != null)
            {
                find.Name = s.Name;
                find.Location = s.Location;

            }
        }
    }
}
