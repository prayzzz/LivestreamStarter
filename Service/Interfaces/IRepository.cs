using System.Collections.Generic;
using System.Linq;

using BaseEntities;

namespace Services.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item) where T : BaseModel;

        void Delete<T>(int? id) where T : BaseModel;

        T GetById<T>(int? id) where T : BaseModel;

        IEnumerable<T> GetList<T>() where T : BaseModel;

        IQueryable<T> GetQueryable<T>() where T : BaseModel;
    }
}