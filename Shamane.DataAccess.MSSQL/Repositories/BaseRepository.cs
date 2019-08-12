using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class BaseRepository<Entity> : IRepository<Entity> where Entity : class
    {
        protected DbSet<Entity> set;
        protected DbContext dbContext;

        public BaseRepository(DbContext dbContext)
        {
            set = dbContext.Set<Entity>();
            this.dbContext = dbContext;
        }

        public virtual void Add(Entity entity)
        {
            ((IBaseEntity)entity).Id = Guid.NewGuid();
            ((IBaseEntity)entity).CreatedAt = DateTime.Now;
            ((IBaseEntity)entity).CreatedBy = GetUserId();
            set.Add(entity);
        }

        public virtual IQueryable<Entity> Get()
        {
            return set;
        }

        public virtual Entity Get(Guid id)
        {
            return set.First(x => ((IBaseEntity)x).Id == id);
        }

        public virtual IQueryable<Entity> Get(Expression<Func<Entity, bool>> expression)
        {
            return set.Where(expression);
        }

        public virtual void Remove(Guid id)
        {
            var entity = Get(id);
            ((IBaseEntity)entity).IsDeleted = true;
            Update(entity);
        }

        public virtual void Update(Entity entity)
        {
            ((IBaseEntity)entity).UpdatedAt = DateTime.Now;
            ((IBaseEntity)entity).UpdateBy = GetUserId();
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public static Guid GetUserId()
        {
            //var identity = (System.Security.Claims.ClaimsPrincipal)System.Threading.Thread.CurrentPrincipal;
            //var principal = System.Threading.Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
            //var userId = identity.Claims.Where(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
            var userId = "459cf6c3-3026-4694-9b9b-0d44ef56dd85";
            return Guid.Parse(userId);
        }
    }
}
