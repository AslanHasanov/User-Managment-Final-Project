using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models.Common;

namespace UserManagmentFinalProject.DataBase.Repo.Common
{
    public class Repository <TEntity,TId>
        where TEntity : Entity<TId>
    {       
        protected static List<TEntity> DbContext = new List<TEntity>();

        public TEntity Add(TEntity entry)
        {
            DbContext.Add(entry);
            return entry;
        }

        public List<TEntity> GetAll()
        {
            return DbContext;
        }
        public List<TEntity> GetAll(Predicate<TEntity> predicate)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (TEntity entity in DbContext)
            {
                if (predicate(entity))
                {
                    entities.Add(entity);
                }
            }

            return entities;
        }

        public TEntity GetById(TId id)
        {
            foreach (TEntity entry in DbContext)
            {
                if (Equals(entry.Id, id)) { return entry; }
            }
            return default(TEntity);
        }

        public void Delete(TEntity entry)
        {
            DbContext.Remove(entry);
        }

        public TEntity Update(TId id, TEntity newEntry)
        {
            TEntity entry = GetById(id);
            newEntry.Id = entry.Id;
            newEntry.CreatedAt = entry.CreatedAt;
            entry = newEntry;
            return entry;

        }
    }
}
