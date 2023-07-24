using System;
using System.Collections.Generic;
using Foxtale.Engine.Components;

namespace Foxtale.Engine.Entities;

public interface IEntity
{
    public Guid Id { get; set; }
    public List<IComponent> Components { get; set; }
    public void AddComponent(IComponent component);
    public T GetComponent<T>() where T : IComponent;
    public bool TryGetComponent<T>(out T component) where T : IComponent;

    public void Destroy()
    {
        foreach (IComponent component in Components) component.Destroy();
        Components.Clear();
    }
}
