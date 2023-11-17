using System.Collections.Generic;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

public class Children : IComponent
{
    public List<IEntity> Nodes { get; }
    public IEntity Entity { get; set; }

    public Children()
    {
        Nodes = new();
        ChildrenSystem.AddComponent(this);
    }

    public Children(IEntity entity)
    {
        Nodes = new()
        {
            entity
        };
        ChildrenSystem.AddComponent(this);
    }
    
    public Children(IEnumerable<IEntity> entities)
    {
        Nodes = new(entities);
        ChildrenSystem.AddComponent(this);
    }

    public Children(params IEntity[] entities)
    {
        Nodes = new(entities);
        ChildrenSystem.AddComponent(this);
    }

    public void Add(IEntity child)
    {
        Nodes.Add(child);
    }

    public bool Remove(IEntity child)
    {
        return Nodes.Remove(child);
    }

    public void Destroy()
    {
        foreach (IEntity entity in Nodes) entity.Destroy();
        Nodes.Clear();
        ChildrenSystem.RemoveComponent(this);
    }
}
