using System;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

public class Event : IComponent
{
    public event EventHandler Handler;
    public IEntity Entity { get; set; }

    public Event()
    {
        EventSystem.AddComponent(this);
    }
    
    public Event(EventHandler handler)
    {
        Handler += handler;
        EventSystem.AddComponent(this);
    }

    public void Destroy()
    {
        EventSystem.RemoveComponent(this);
    }

    public void Call(EventArgs args = null)
    {
        Handler?.Invoke(Entity, args ?? EventArgs.Empty);
    }

    public void AddHandler(EventHandler handler)
    {
        Handler += handler;
    }
}