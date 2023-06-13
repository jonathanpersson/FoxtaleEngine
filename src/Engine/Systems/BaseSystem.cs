using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MgGame.Engine.Components;

namespace MgGame.Engine.Systems;

public abstract class BaseSystem<T> where T : IComponent
{
    /// <summary>
    /// Contains all registered components of type T
    /// </summary>
    protected static List<T> components { get; set; } = new();

    /// <summary>
    /// Contains all uninitialzied components of type T
    /// Enqueued components are initialized on next update 
    /// </summary>
    protected static Queue<T> uninitialized { get; set; } = new();

    /// <summary>
    /// Add a component to the system
    /// </summary>
    /// <param name="component">Component to add</param>
    public static void AddComponent(T component)
    {
        components.Add(component);
        uninitialized.Enqueue(component);
    }

    public static void Initialize() { }

    /// <summary>
    /// Update components in system
    /// </summary>
    /// <param name="gameTime">Current game time</param>
    public static void Update(GameTime gameTime)
    {
        while (uninitialized.TryDequeue(out T component))
        {
            component.Initialize();
        }

        foreach (T component in components)
        {
            component.Update(gameTime);
        }
    }
}
