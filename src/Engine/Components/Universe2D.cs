using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;

namespace MgGame.Engine.Components;

public class Universe2D : IComponent
{
    List<IEntity> _content;
    public IEntity Entity { get; set; }

    public Universe2D()
    {
        _content = new();
        Universe2DSystem.AddComponent(this);
    }

    public void Initialize()
    {

    }

    public void Update(GameTime gameTime)
    {

    }
}
