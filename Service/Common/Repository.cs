using System;
using System.Collections.Generic;
using System.Linq;

using BaseEntities;

using Services.Interfaces;

namespace Services.Common
{
    public class Repository : IRepository
    {
        private readonly Dictionary<Type, IList<BaseModel>> repository;

        public Repository()
        {
            this.repository = new Dictionary<Type, IList<BaseModel>>();
        }

        public void Add<T>(T item) where T : BaseModel
        {
            if (item.IsStored)
            {
                return;
            }

            IList<BaseModel> items;

            if (this.repository.TryGetValue(typeof(T), out items) && items != null)
            {
                item.Id = items.Max(x => x.Id) + 1;
                items.Add(item);
                return;
            }

            item.Id = 1;
            this.repository.Add(typeof(T), new List<BaseModel> { item });
        }

        public void Delete<T>(int? id) where T : BaseModel
        {
            if (id == null)
            {
                return;
            }

            IList<BaseModel> items;

            if (this.repository.TryGetValue(typeof(T), out items) && items != null)
            {
                var itemToRemove = items.FirstOrDefault(x => x.Id == id);

                if (itemToRemove != null)
                {
                    items.Remove(itemToRemove);
                }
            }
        }

        public T GetById<T>(int? id) where T : BaseModel
        {
            if (id == null)
            {
                return null;
            }

            IList<BaseModel> items;

            if (this.repository.TryGetValue(typeof(T), out items) && items != null)
            {
                return items.FirstOrDefault(x => x.Id == id) as T;
            }

            return null;
        }

        public IEnumerable<T> GetList<T>() where T : BaseModel
        {
            IList<BaseModel> items;

            if (this.repository.TryGetValue(typeof(T), out items) && items != null)
            {
                return items.Cast<T>();
            }

            return new List<T>();
        }

        public IQueryable<T> GetQueryable<T>() where T : BaseModel
        {
            IList<BaseModel> items;

            if (this.repository.TryGetValue(typeof(T), out items) && items != null)
            {
                return items.Cast<T>().AsQueryable();
            }

            return new List<T>().AsQueryable();
        }
    }
}