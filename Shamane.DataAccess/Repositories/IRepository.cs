using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Shamane.DataAccess.Repositories
{
    public interface IRepository<Entity>
    {
        IQueryable<Entity> Get();
        Entity Get(Guid id);
        void Add(Entity entity);
        void Update(Entity entity);
        void Remove(Guid id);
        IQueryable<Entity> Get(Expression<Func<Entity, bool>> expression);
    }
}
