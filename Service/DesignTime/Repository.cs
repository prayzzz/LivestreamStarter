using System.Collections.Generic;
using System.Linq;

using BaseEntities;

using Services.Interfaces;

namespace Services.DesignTime
{
    public class Repository : IRepository
    {
        public void Add<T>(T item) where T : BaseModel
        {
        }

        public void Delete<T>(int? id) where T : BaseModel
        {
        }

        public T GetById<T>(int? id) where T : BaseModel
        {
            return null;
        }

        public IEnumerable<T> GetList<T>() where T : BaseModel
        {
            return new List<T>();
        }

        public IQueryable<T> GetQueryable<T>() where T : BaseModel
        {
            return new List<T>().AsQueryable();
        }
    }
}
