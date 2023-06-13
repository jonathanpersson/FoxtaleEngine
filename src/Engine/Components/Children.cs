using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;
using System;

namespace MgGame.Engine.Components;

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

    public void Initialize()
    {

    }

    public void Update(GameTime gameTime) { }

    public void Add(IEntity child)
    {
        Nodes.Add(child);
    }

    public bool Remove(IEntity child)
    {
        return Nodes.Remove(child);
    }
}
