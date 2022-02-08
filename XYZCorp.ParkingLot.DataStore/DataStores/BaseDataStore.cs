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
using XYZCorp.ParkingLot.DataStore.DataStores.Interfaces;

namespace XYZCorp.ParkingLot.DataStore.DataStores
{
    public abstract class BaseDataStore : IBaseDataStore
    {
        public readonly SqlDbContext context;
        public readonly IMapper mapper;
        public BaseDataStore(SqlDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected List<T> ExecuteQuery<T>(string query, Dictionary<string, object> Params = null)
        {
            var currentType = typeof(T);
            var retval = new List<T>();

            using (var cmd = context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = query;
                if (cmd.Connection.State != ConnectionState.Open) { cmd.Connection.Open(); }

                if (Params != null)
                {
                    foreach (KeyValuePair<string, object> p in Params)
                    {
                        cmd.CommandText += $" {p.Value}, ";
                    }

                    cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.LastIndexOf(","));
                }

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var row = new ExpandoObject() as IDictionary<string, object>;
                        for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                        {
                            row.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
                        }

                        var props = currentType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetSetMethod() != null);
                        var obj = Activator.CreateInstance(currentType);

                        foreach (var prop in props)
                        {
                            try { prop.SetValue(obj, row[prop.Name]); } catch (Exception e) { prop.SetValue(obj, null); }
                        }

                        retval.Add((T)Convert.ChangeType(obj, currentType));
                    }
                }
            }

            return (List<T>)Convert.ChangeType(retval, typeof(List<T>));
        }

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
