using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;

namespace MgGame.Engine.Components;

public class Children : IComponent
{
    List<IEntity> _children;
    public IEntity Entity { get; set; }

    public Children()
    {
        _children = new();
        ChildrenSystem.AddComponent(this);
    }

    public void Initialize()
    {

    }

    public void Update(GameTime gameTime)
    {

    }
}
