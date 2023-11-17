using System.Collections.Generic;
using Foxtale.Components;
using Microsoft.Xna.Framework;

namespace Foxtale.Systems;

public abstract class BaseSystem<T> where T : IComponent
{
    /// <summary>
    /// Contains all registered components of type T
    /// </summary>
    protected static List<T> components { get; set; } = new();

    /// <summary>
    /// Add a component to the system
    /// </summary>
    /// <param name="component">Component to add</param>
    public static void AddComponent(T component)
    {
        components.Add(component);
    }

    /// <summary>
    /// Remove a component from the system
    /// </summary>
    /// <param name="component">Component to remove</param>
    public static void RemoveComponent(T component)
    {
        if (components.Contains(component)) components.Remove(component);
    }
}
