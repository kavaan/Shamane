using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class BaseRepository<Entity> : IRepository<Entity> where Entity : class
    {
        protected DbSet<Entity> set;
        protected DbContext dbContext;
        //private readonly ClaimsPrincipal _principal;

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

        public Guid GetUserId()
        {
            var threadUserId = Thread.GetData(Thread.GetNamedDataSlot("userId"));
            var currentPrincipal = Thread.CurrentPrincipal;
            var identity = (System.Security.Claims.ClaimsPrincipal)System.Threading.Thread.CurrentPrincipal;
            var principal = System.Threading.Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
            var userId = identity.Claims.Where(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
            return Guid.Parse(userId);
        }
    }
}
