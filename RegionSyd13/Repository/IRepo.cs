using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void UpdateSpecific(string column, string value, int ID);
        void AddSpecific(string columns, string values);
    }
}
