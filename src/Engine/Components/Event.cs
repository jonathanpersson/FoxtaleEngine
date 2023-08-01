using System;
using Foxtale.Engine.Entities;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Components;

public class Event : IComponent
{
    public event EventHandler Handler;
    public IEntity Entity { get; set; }

    public Event(EventHandler handler)
    {
        Handler += handler;
        EventSystem.AddComponent(this);
    }

    public void Initialize() { }

    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        EventSystem.RemoveComponent(this);
    }
}