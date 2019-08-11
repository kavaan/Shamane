using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Factories
{
    public interface IModelFactory<Entity,Dto>
        where Entity : class
        where Dto  : class
    {
        IEnumerable<Entity> CreateEntity(IEnumerable<Dto> dtos);
        IEnumerable<Dto> CreateDto(IEnumerable<Entity> entities);
        Entity CreateEntity(Dto dto);
        Dto CreateDto(Entity entity);
    }
}
