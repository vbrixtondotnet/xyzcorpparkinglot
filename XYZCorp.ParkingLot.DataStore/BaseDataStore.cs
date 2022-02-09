using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.ParkingLot.DataStore.Interfaces;

namespace XYZCorp.ParkingLot.DataStore
{
    public abstract class BaseDataStore : IBaseDataStore
    {
        public BaseDataStore(){}

        

        public virtual T ConvertObject<T>(object item)
        {
            return (T)Convert.ChangeType(item, typeof(T));
        }

        public virtual Task<T> Add<T>(object item)
        {
            throw new NotImplementedException();
        }

        public object ConvertToJson(object item)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Get<T>(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public string GetId(object item)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Update<T>(object item)
        {
            throw new NotImplementedException();
        }


        

    }
}
