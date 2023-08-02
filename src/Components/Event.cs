using System;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

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