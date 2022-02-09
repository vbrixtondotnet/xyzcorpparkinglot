using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XYZCorp.ParkingLot.DataStore.Interfaces
{
    public interface IBaseDataStore
    {
        T Get<T>(int id);
        List<T> GetAll<T>();
        void Delete(int id);
        Task<T> Add<T>(object item);
        Task<T> Update<T>(object item);
        string GetId(object item);
        object ConvertToJson(object item);
    }
}
