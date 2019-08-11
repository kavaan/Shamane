using Shamane.Common.Tools;
using Shamane.Domain;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class ModelFactory<Entity, Dto> : IModelFactory<Entity, Dto>
        where Entity : class
        where Dto : class
    {
        public virtual Entity CreateEntity(Dto dto)
        {
            return ObjectEx.ShallowCopy<Entity>(dto);

        }
        public virtual IEnumerable<Entity> CreateEntity(IEnumerable<Dto> dtos)
        {
            return dtos.Select(CreateEntity);

        }

        public virtual IEnumerable<Dto> CreateDto(IEnumerable<Entity> entities)
        {
            return entities.Select(CreateDto);
        }

        public virtual Dto CreateDto(Entity entity)
        {
            var result = ObjectEx.ShallowCopy<Dto>(entity);
            if (((IBaseEntity)entity).Id != null && ((IBaseEntity)entity).Id != Guid.Empty)
            {
                PropertyInfo idProperty = result.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    idProperty.SetValue(result, ((IBaseEntity)entity).Id.ToString());
                }
            }
            return result;
        }
    }
}
