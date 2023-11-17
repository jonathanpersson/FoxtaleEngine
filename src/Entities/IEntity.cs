using System;
using System.Collections.Generic;
using Foxtale.Components;
using Foxtale.Core;

namespace Foxtale.Entities;

public interface IEntity
{
    public bool Active { get; set;}
    public Guid Id { get; set; }
    public List<IComponent> Components { get; set; }
    public void AddComponent(IComponent component);
    public T GetComponent<T>() where T : IComponent;
    public bool TryGetComponent<T>(out T component) where T : IComponent;

    public void Destroy()
    {
        Logger.Log(LogLevel.Information, $"Destroying entity with entity ID: {Id}");
        foreach (IComponent component in Components) component.Destroy();
        Components.Clear();
    }
}
