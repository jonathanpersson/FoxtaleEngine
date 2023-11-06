using System;
using System.Collections.Generic;
using Foxtale.Components;
using Foxtale.Core;
using Foxtale.Exceptions;

namespace Foxtale.Entities;

public abstract class Entity : IEntity
{
    public bool Active { get; set; } = true;

    /// <summary>
    /// Unique identifier for the entity
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// List of components attached to the entity
    /// </summary>
    public List<IComponent> Components { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Components = new List<IComponent>();
        Logger.Log(LogLevel.Information, $"New entity created with GUID: {Id}");
    }

    /// <summary>
    /// Add a component to the entity
    /// </summary>
    /// <param name="component">Component to add</param>
    public void AddComponent(IComponent component)
    {
        Components.Add(component);
        component.Entity = this;
    }

    /// <summary>
    /// Get a component from the entity
    /// </summary>
    /// <typeparam name="T">Component type</typeparam>
    /// <returns>The component, or default value for type T</returns>
    public T GetComponent<T>() where T : IComponent
    {
        foreach (IComponent component in Components)
        {
            if (component is T comp) return comp;
        }
        throw new MissingComponentException(this, typeof(T));
    }

    /// <summary>
    /// Try to get a component from the entity
    /// </summary>
    /// <param name="component">The resulting component is stored here</param>
    /// <typeparam name="T">Expected component type</typeparam>
    /// <returns>True iff component is not equal to default value for type T</returns>
    public bool TryGetComponent<T>(out T component) where T : IComponent
    {
        try
        {
            component = GetComponent<T>();
            return true;
        }
        catch (MissingComponentException)
        {
            Logger.Log(LogLevel.Error, $"Failed to get component of type {typeof(T)}");
            component = default(T);
        }
        return false;
    }
}
